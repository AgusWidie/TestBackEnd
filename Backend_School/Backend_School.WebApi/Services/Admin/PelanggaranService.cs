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

    public class PelanggaranService : IPelanggaranService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "Pelanggaran";
        public PelanggaranService(IConfiguration Configuration, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _logErrorService = logErrorService;
        }

        public async Task<IEnumerable<PelanggaranResponse>> GetPelanggaranById(IdPelanggaranRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<PelanggaranResponse> DataPelanggaran = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    DataPelanggaran = await connection.QueryAsync<PelanggaranResponse>(new CommandDefinition("sp_GetPelanggaranById", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "Pelanggaran";
                    logError.NamaAction = "GetPelanggaranById";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataPelanggaran;
            }
        }

        public async Task<IEnumerable<PelanggaranResponse>> CheckAddPelanggaran(CheckPelanggaranRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<PelanggaranResponse> DataPelanggaran = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    DataPelanggaran = await connection.QueryAsync<PelanggaranResponse>(new CommandDefinition("sp_CheckAddPelanggaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "Pelanggaran";
                    logError.NamaAction = "CheckAddPelanggaran";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }
                return DataPelanggaran;
            }
        }

        public async Task<IEnumerable<PelanggaranResponse>> AddPelanggaran(PelanggaranAddRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<PelanggaranResponse> DataPelanggaran = null;
                    try
                    {
                        parameter.TanggalBuat = DateTime.Now;
                        DataPelanggaran = await connection.QueryAsync<PelanggaranResponse>(new CommandDefinition("sp_AddPelanggaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataPelanggaran, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Pelanggaran";
                        logError.NamaAction = "AddPelanggaran";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }
                    return DataPelanggaran;
                }

            }
        }

        public async Task<IEnumerable<PelanggaranResponse>> EditPelanggaran(PelanggaranUpdateRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<PelanggaranResponse> DataPelanggaran = null;
                    try
                    {
                        parameter.TanggalPerbarui = DateTime.Now;
                        DataPelanggaran = await connection.QueryAsync<PelanggaranResponse>(new CommandDefinition("sp_EditPelanggaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataPelanggaran, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Pelanggaran";
                        logError.NamaAction = "EditPelanggaran";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }
                    return DataPelanggaran;
                }

            }
        }

        public async Task<int> DeletePelanggaran(long Id, CancellationToken cancellationToken)
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
                        resultData = await connection.ExecuteAsync(new CommandDefinition("sp_DeletePelanggaran", Id, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Pelanggaran";
                        logError.NamaAction = "DeletePelanggaran";
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
