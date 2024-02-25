using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using Backend_School.WebApi.Services.Interface;
using Backend_School.WebApi.RabbitMQ;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Backend_School.WebApi.Services
{

    public class MenuPenggunaRoleService : IMenuPenggunaRoleService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "MenuPenggunaRole";
        public MenuPenggunaRoleService(IConfiguration Configuration, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _logErrorService = logErrorService;
        }

        public async Task<IEnumerable<MenuResponse>> GetMenuPengguna(NamaPenggunaRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                IEnumerable<MenuResponse> DataMenuPengguna = null;
                try
                {
                    DataMenuPengguna = await connection.QueryAsync<MenuResponse>(new CommandDefinition("sp_GetMenuPengguna", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "Menu";
                    logError.NamaAction = "GetMenuPengguna";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataMenuPengguna;

            }
        }

        public async Task<IEnumerable<MenuHeaderResponse>> GetMenuHeaderPengguna(IdMenuPenggunaRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                IEnumerable<MenuHeaderResponse> DataMenuPengguna = null;
                try
                {
                    DataMenuPengguna = await connection.QueryAsync<MenuHeaderResponse>(new CommandDefinition("sp_GetMenuHeaderPengguna", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "Menu";
                    logError.NamaAction = "GetMenuPengguna";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataMenuPengguna;

            }
        }
    }
}
