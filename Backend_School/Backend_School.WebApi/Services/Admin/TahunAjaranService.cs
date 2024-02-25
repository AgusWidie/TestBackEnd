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

    public class TahunAjaranService : ITahunAjaranService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "TahunAjaran";
        public TahunAjaranService(IConfiguration Configuration, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _logErrorService = logErrorService;
        }

        public async Task<IEnumerable<TahunAjaranResponse>> GetTahunAjaranById(IdTahunAjaranRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<TahunAjaranResponse> DataTahunAjaran = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataTahunAjaran = await connection.QueryAsync<TahunAjaranResponse>(new CommandDefinition("sp_GetTahunAjaranById", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "TahunAjaran";
                    logError.NamaAction = "GetTahunAjaranById";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataTahunAjaran;
            }
        }

        public async Task<IEnumerable<TahunAjaranResponse>> CheckAddTahunAjaran(CheckTahunAjaranRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<TahunAjaranResponse> DataTahunAjaran = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataTahunAjaran = await connection.QueryAsync<TahunAjaranResponse>(new CommandDefinition("sp_CheckAddTahunAjaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "TahunAjaran";
                    logError.NamaAction = "CheckAddTahunAjaran";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataTahunAjaran;
            }
        }

        public async Task<IEnumerable<TahunAjaranResponse>> AddTahunAjaran(TahunAjaranAddRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<TahunAjaranResponse> DataTahunAjaran = null;
                    try
                    {
                        parameter.TanggalBuat = DateTime.Now;
                        DataTahunAjaran = await connection.QueryAsync<TahunAjaranResponse>(new CommandDefinition("sp_AddTahunAjaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataTahunAjaran, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "TahunAjaran";
                        logError.NamaAction = "AddTahunAjaran";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataTahunAjaran;
                }

            }
        }

        public async Task<IEnumerable<TahunAjaranResponse>> EditTahunAjaran(TahunAjaranUpdateRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<TahunAjaranResponse> DataTahunAjaran = null;
                    try
                    {
                        parameter.TanggalPerbarui = DateTime.Now;
                        DataTahunAjaran = await connection.QueryAsync<TahunAjaranResponse>(new CommandDefinition("sp_EditTahunAjaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataTahunAjaran, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "TahunAjaran";
                        logError.NamaAction = "EditTahunAjaran";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataTahunAjaran;
                }
            }
        }

        public async Task<int> DeleteTahunAjaran(long Id, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    int resultData = 0;
                    try
                    {
                        resultData = await connection.ExecuteAsync(new CommandDefinition("sp_DeleteTahunAjaran", Id, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "TahunAjaran";
                        logError.NamaAction = "DeleteTahunAjaran";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return resultData;
                }

            }
        }
    }
}
