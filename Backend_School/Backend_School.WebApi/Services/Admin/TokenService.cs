using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using Backend_School.WebApi.Services.Interface;
using Backend_School.WebApi.RabbitMQ;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using static Dapper.SqlMapper;

namespace Backend_School.WebApi.Services
{

    public class TokenService : ITokenService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public DateTime? ExpiredToken;
        public string routingKey = "Token";
        public TokenService(IConfiguration Configuration, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _logErrorService = logErrorService;
        }

        public async Task<IEnumerable<TokenResponse>> AddToken(TokenAddRequest parameter, CancellationToken cancellationToken)
        {

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Disable BCC4003
                parameter.Token = GenerateJSONWebToken(parameter.NamaPengguna, parameter.NamaRole, parameter.NamaGuru, parameter.Email);
                parameter.ExpiredToken = DateTime.Now.AddHours(Convert.ToInt32(_configuration["Jwt:expiredToken"]));
                parameter.TanggalBuat = DateTime.Now;

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<TokenResponse> DataToken = null;
                    try
                    {
                        parameter.TanggalBuat = System.DateTime.Now;
                        DataToken = await connection.QueryAsync<TokenResponse>(new CommandDefinition("sp_AddToken", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    { 

                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Token";
                        logError.NamaAction = "AddToken";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataToken;
                }

            }
        }

        public async Task<IEnumerable<CheckTokenResponse>> GetCheckToken(CheckTokenRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {

                    var DataToken = await connection.QueryAsync<CheckTokenResponse>(new CommandDefinition("sp_CheckToken", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                    transaction.Dispose();
                    return DataToken;
                }
            }
        }

        public string GenerateJSONWebToken(string NamaPengguna, string NamaRole, string NamaGuru, string Email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, NamaPengguna),
                new Claim(ClaimTypes.Role, NamaRole),
                new Claim(ClaimTypes.NameIdentifier, NamaGuru),
                new Claim(ClaimTypes.Email, Email)
               
            });

            //create the jwt
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = DateTime.Now.AddHours(Convert.ToInt32(_configuration["Jwt:expiredToken"]));
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenUser = (JwtSecurityToken)
                tokenHandler.CreateJwtSecurityToken(issuer: _configuration["Jwt:Issuer"].ToString(), audience: _configuration["Jwt:Audience"].ToString(),
                                                    subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: credentials);
            var tokenString = tokenHandler.WriteToken(tokenUser);
            return tokenString;
        }
    }
}
