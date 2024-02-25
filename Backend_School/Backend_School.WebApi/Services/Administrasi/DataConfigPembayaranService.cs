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

namespace Backend_School.WebApi.Services.Administrasi
{
    public class DataConfigPembayaranService : IDataConfigPembayaranService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "DataConfigPembayaran";

        public DataConfigPembayaranService(IConfiguration Configuration, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _logErrorService = logErrorService;
        }

        public async Task<IEnumerable<DataConfigPembayaranResponse>> GetIdConfigPembayaran(IdConfigPembayaranRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<DataConfigPembayaranResponse> DataConfigPembayaran = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataConfigPembayaran = await connection.QueryAsync<DataConfigPembayaranResponse>(new CommandDefinition("sp_GetIdConfigPembayaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "DataConfigPembayaran";
                    logError.NamaAction = "GetConfigPembayaran";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }
                return DataConfigPembayaran;
            }
        }

        public async Task<IEnumerable<DataConfigPembayaranResponse>> GetNamaConfigPembayaran(NamaConfigPembayaranRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<DataConfigPembayaranResponse> DataConfigPembayaran = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataConfigPembayaran = await connection.QueryAsync<DataConfigPembayaranResponse>(new CommandDefinition("sp_GetNamaConfigPembayaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "DataConfigPembayaran";
                    logError.NamaAction = "GetConfigPembayaran";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }
                return DataConfigPembayaran;
            }
        }
    }
}
