using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using Backend_School.WebApi.RabbitMQ;
using Dapper;
using Microsoft.Extensions.Configuration;
using Backend_School.WebApi.Helper;
using Backend_School.WebApi.Services.Interface;
using System.Linq;

namespace Backend_School.WebApi.Services
{
    public interface ILoginService
    {
        Task<bool> ConnectDB(CancellationToken cancellationToken = default);
        Task<IEnumerable<TokenResponse>> Login(LoginRequest parameter, CancellationToken cancellationToken = default);
    }
    public class LoginService : ILoginService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly ITokenService _tokenService;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "Login";
        public LoginService(IConfiguration Configuration, IMessageProducer MessageProducer, ITokenService tokenService, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _tokenService = tokenService;
            _logErrorService = logErrorService;

        }

        public async Task<bool> ConnectDB(CancellationToken cancellationToken)
        {

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public async Task<IEnumerable<TokenResponse>> Login(LoginRequest parameter, CancellationToken cancellationToken)
        {

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<LoginResponse> DataPengguna = null;
                    IEnumerable<TokenResponse> TokenPengguna = null;
                    try
                    {
                        parameter.Pass = EncryptMD5.Encrypt(parameter.Pass);
                        DataPengguna = await connection.QueryAsync<LoginResponse>(new CommandDefinition("sp_Login", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Commit();
                        transaction.Dispose();

                        TokenAddRequest token = new TokenAddRequest();
                        if (DataPengguna.Any()) {
                            foreach (var Pengguna in DataPengguna)
                            {
                                token.NamaPengguna = Pengguna.NamaPengguna;
                                token.NamaRole = Pengguna.NamaRole;
                                token.NamaGuru = Pengguna.NamaGuru;
                                token.Email = Pengguna.Email;
                            }
                        } else {
                            return TokenPengguna;
                        }
                        TokenPengguna = await _tokenService.AddToken(token, cancellationToken);

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Login";
                        logError.NamaAction = "Login";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }
                    return TokenPengguna;
                }

            }
        }

    }
}
