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
    public class JadwalPiketGuruService : IJadwalPiketGuruService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "JadwalPiket";

        public JadwalPiketGuruService(IConfiguration Configuration, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _logErrorService = logErrorService;
        }

        public async Task<IEnumerable<JadwalPiketGuruResponse>> GetJadwalPiketGuruSearch(SearchJadwalPiketGuruRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<JadwalPiketGuruResponse> DataJadwalPiketGuru = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataJadwalPiketGuru = await connection.QueryAsync<JadwalPiketGuruResponse>(new CommandDefinition("sp_GetJadwalPiketGuruSearch", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "JadwalPiketGuru";
                    logError.NamaAction = "GetJadwalPiketGuruSearch";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataJadwalPiketGuru;
            }
        }

        public async Task<IEnumerable<JadwalPiketGuruResponse>> CheckAddJadwalPiketGuru(CheckJadwalPiketGuruRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<JadwalPiketGuruResponse> DataJadwalPiketGuru = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataJadwalPiketGuru = await connection.QueryAsync<JadwalPiketGuruResponse>(new CommandDefinition("sp_CheckJadwalPiketGuru", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "JadwalPiketGuru";
                    logError.NamaAction = "CheckAddJadwalPiketGuru";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataJadwalPiketGuru;
            }
        }

        public async Task<IEnumerable<JadwalPiketGuruResponse>> AddJadwalPiket(JadwalPiketGuruAddRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<JadwalPiketGuruResponse> DataJadwalPiketGuru = null;
                    try
                    {
                        parameter.TanggalBuat = DateTime.Now;
                        DataJadwalPiketGuru = await connection.QueryAsync<JadwalPiketGuruResponse>(new CommandDefinition("sp_AddJadwalPiketGuru", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataKelas, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "JadwalPiketGuru";
                        logError.NamaAction = "AddJadwalPiketGuru";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataJadwalPiketGuru;
                }

            }
        }

        public async Task<IEnumerable<JadwalPiketGuruResponse>> UpdateJadwalPiket(JadwalPiketGuruUpdateRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<JadwalPiketGuruResponse> DataJadwalPiketGuru = null;
                    try
                    {
                        parameter.TanggalPerbarui = DateTime.Now;
                        DataJadwalPiketGuru = await connection.QueryAsync<JadwalPiketGuruResponse>(new CommandDefinition("sp_EditJadwalPiketGuru", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataKelas, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "JadwalPiketGuru";
                        logError.NamaAction = "AddJadwalPiketGuru";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataJadwalPiketGuru;
                }

            }
        }

        public async Task<int> DeleteJadwalPiketGuru(long Id, CancellationToken cancellationToken)
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
                        resultData = await connection.ExecuteAsync(new CommandDefinition("sp_DeleteJadwalPiketGuru", Id, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "JadwalPiketGuru";
                        logError.NamaAction = "DeleteJadwalGuru";
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
