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


    public class PembayaranService : IPembayaranService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly IDataConfigPembayaranService _dataConfigPembayaranService;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "Pembayaran";
        public PembayaranService(IConfiguration Configuration, IDataConfigPembayaranService dataConfigPembayaranService, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _dataConfigPembayaranService = dataConfigPembayaranService;
            _logErrorService = logErrorService;

        }

        public async Task<IEnumerable<PembayaranResponse>> GetPembayaranSearch(SearchPembayaranRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<PembayaranResponse> DataPembayaran = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataPembayaran = await connection.QueryAsync<PembayaranResponse>(new CommandDefinition("sp_GetPembayaranSearch", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));

                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "Pembayaran";
                    logError.NamaAction = "GetPembayaranSearch";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }
                return DataPembayaran;
            }
        }

        public async Task<IEnumerable<PembayaranResponse>> CheckAddPembayaran(CheckPembayaranRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<PembayaranResponse> DataPembayaran = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataPembayaran = await connection.QueryAsync<PembayaranResponse>(new CommandDefinition("sp_CheckAddPembayaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "Pembayaran";
                    logError.NamaAction = "CheckAddPembayaran";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }
                return DataPembayaran;
            }
        }

        public async Task<IEnumerable<PembayaranResponse>> AddPembayaran(PembayaranAddRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }


                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<PembayaranResponse> DataPembayaran = null;

                    IdConfigPembayaranRequest model = new IdConfigPembayaranRequest();
                    model.Id = parameter.IdConfigPembayaran;
                    var dataConfig = await _dataConfigPembayaranService.GetIdConfigPembayaran(model, cancellationToken);
                    if (dataConfig != null) {
                        foreach (var data in dataConfig)
                        {
                            parameter.IdConfigPembayaran = data.Id;
                            parameter.NilaiPembayaran = data.NilaiPembayaran;
                        }
                    } else {

                        return DataPembayaran;
                    }

                    try
                    {
                        parameter.TanggalBuat = DateTime.Now;
                        DataPembayaran = await connection.QueryAsync<PembayaranResponse>(new CommandDefinition("sp_AddPembayaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataPembayaran, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Pembayaran";
                        logError.NamaAction = "AddPembayaran";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataPembayaran;
                }

            }
        }

        public async Task<IEnumerable<PembayaranResponse>> EditPembayaran(PembayaranUpdateRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<PembayaranResponse> DataPembayaran = null;

                    IdConfigPembayaranRequest model = new IdConfigPembayaranRequest();
                    model.Id = parameter.IdConfigPembayaran;
                    var dataConfig = await _dataConfigPembayaranService.GetIdConfigPembayaran(model, cancellationToken);
                    if (dataConfig != null)
                    {
                        foreach (var data in dataConfig)
                        {
                            parameter.IdConfigPembayaran = data.Id;
                            parameter.NilaiPembayaran = data.NilaiPembayaran;
                        }
                    }
                    else
                    {
                        return DataPembayaran;
                    }

                    try
                    {
                        parameter.TanggalPerbarui = DateTime.Now;
                        DataPembayaran = await connection.QueryAsync<PembayaranResponse>(new CommandDefinition("sp_EditPembayaran", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataPembayaran, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Pembayaran";
                        logError.NamaAction = "EditPembayaran";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataPembayaran;
                }


            }
        }

        public async Task<int> DeletePembayaran(long Id, CancellationToken cancellationToken)
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
                        resultData = await connection.ExecuteAsync(new CommandDefinition("sp_DeletePembayaran", Id, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Pembayaran";
                        logError.NamaAction = "DeletePembayaran";
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
