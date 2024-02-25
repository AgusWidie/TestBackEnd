using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using Backend_School.WebApi.RabbitMQ;
using Backend_School.WebApi.Services.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services
{


    public class PelajaranService : IPelajaranService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "Pelajaran";
        public PelajaranService(IConfiguration Configuration, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _logErrorService = logErrorService;
        }

        public async Task<IEnumerable<PelajaranResponse>> GetPelajaranById(IdPelajaranRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<PelajaranResponse> DataPelajaran = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataPelajaran = await connection.QueryAsync<PelajaranResponse>(new CommandDefinition("sp_GetPelajaranById", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "Pelajaran";
                    logError.NamaAction = "GetPelajaranById";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }
                return DataPelajaran;
            }
        }

        public async Task<IEnumerable<PelajaranResponse>> CheckAddPelajaran(CheckPelajaranRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<PelajaranResponse> DataPelajaran = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataPelajaran = await connection.QueryAsync<PelajaranResponse>(new CommandDefinition("sp_CheckAddPelajaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "Pelajaran";
                    logError.NamaAction = "CheckAddPelajaran";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }
                return DataPelajaran;
            }
        }

        public async Task<IEnumerable<PelajaranResponse>> AddPelajaran(PelajaranAddRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<PelajaranResponse> DataPelajaran = null;
                    try
                    {
                        parameter.TanggalBuat = DateTime.Now;
                        DataPelajaran = await connection.QueryAsync<PelajaranResponse>(new CommandDefinition("sp_AddPelajaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataPelajaran, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Pelajaran";
                        logError.NamaAction = "AddPelajaran";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataPelajaran;
                }

            }
        }

        public async Task<IEnumerable<PelajaranResponse>> EditPelajaran(PelajaranUpdateRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<PelajaranResponse> DataPelajaran = null;
                    try
                    {
                        parameter.TanggalPerbarui = DateTime.Now;
                        DataPelajaran = await connection.QueryAsync<PelajaranResponse>(new CommandDefinition("sp_EditPelajaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataPelajaran, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Pelajaran";
                        logError.NamaAction = "EditPelajaran";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }
                    return DataPelajaran;
                }

            }
        }

        public async Task<int> DeletePelajaran(long Id, CancellationToken cancellationToken)
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
                        resultData = await connection.ExecuteAsync(new CommandDefinition("sp_DeletePelajaran", Id, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Pelajaran";
                        logError.NamaAction = "DeletePelajaran";
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
