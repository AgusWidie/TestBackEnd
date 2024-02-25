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

    public class PelanggaranSiswaService : IPelanggaranSiswaService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "PelanggaranSiswa";
        public PelanggaranSiswaService(IConfiguration Configuration, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _logErrorService = logErrorService;
        }

        public async Task<IEnumerable<PelanggaranSiswaResponse>> GetPelanggaranSiswaSearch(SearchPelanggaranSiswaRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<PelanggaranSiswaResponse> DataPelanggaranSiswa = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataPelanggaranSiswa = await connection.QueryAsync<PelanggaranSiswaResponse>(new CommandDefinition("sp_GetPelanggaranSiswaSearch", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "PelanggaranSiswa";
                    logError.NamaAction = "GetPelanggaranSiswaBySearch";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataPelanggaranSiswa;
            }
        }

        public async Task<IEnumerable<PelanggaranSiswaResponse>> AddPelanggaranSiswa(PelanggaranSiswaAddRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<PelanggaranSiswaResponse> DataPelanggaranSiswa = null;
                    try
                    {
                        parameter.TanggalBuat = DateTime.Now;
                        DataPelanggaranSiswa = await connection.QueryAsync<PelanggaranSiswaResponse>(new CommandDefinition("sp_AddPelanggaranSiswa", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataPelanggaranSiswa, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "PelanggaranSiswa";
                        logError.NamaAction = "AddPelanggaranSiswa";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataPelanggaranSiswa;
                }

            }
        }

        public async Task<IEnumerable<PelanggaranSiswaResponse>> EditPelanggaranSiswa(PelanggaranSiswaUpdateRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<PelanggaranSiswaResponse> DataPelanggaranSiswa = null;
                    try
                    {
                        parameter.TanggalPerbarui = DateTime.Now;
                        DataPelanggaranSiswa = await connection.QueryAsync<PelanggaranSiswaResponse>(new CommandDefinition("sp_EditPelanggaranSiswa", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataPelanggaranSiswa, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "PelanggaranSiswa";
                        logError.NamaAction = "EditPelanggaranSiswa";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataPelanggaranSiswa;
                }

            }
        }

        public async Task<int> DeletePelanggaranSiswa(long Id, CancellationToken cancellationToken)
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
                        resultData = await connection.ExecuteAsync(new CommandDefinition("sp_DeletePelanggaranSiswa", Id, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "PelanggaranSiswa";
                        logError.NamaAction = "DeletePelanggaranSiswa";
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
