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

    public class UangBangunanService : IUangBangunanService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly IDataConfigPembayaranService _dataConfigPembayaranService;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "UangBangunan";
        public UangBangunanService(IConfiguration Configuration, IDataConfigPembayaranService dataConfigPembayaranService, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _dataConfigPembayaranService = dataConfigPembayaranService;
            _logErrorService = logErrorService;
        }

        public async Task<IEnumerable<UangBangunanResponse>> GetUangBangunanSearch(SearchUangBangunanRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<UangBangunanResponse> DataUangBangunan = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataUangBangunan = await connection.QueryAsync<UangBangunanResponse>(new CommandDefinition("sp_GetUangBangunanSearch", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "UangBangunan";
                    logError.NamaAction = "GetUangBangunanSearch";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataUangBangunan;
            }
        }

        public async Task<IEnumerable<TotalUangBangunanResponse>> TotalUangBangunan(TotalUangBangunanRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<TotalUangBangunanResponse> DataTotalUangBangunan = null;
                    try
                    {
                        DataTotalUangBangunan = await connection.QueryAsync<TotalUangBangunanResponse>(new CommandDefinition("sp_TotalBayarUangBangunan", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "UangBangunan";
                        logError.NamaAction = "TotalUangBangunan";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }
                    return DataTotalUangBangunan;
                }

            }
        }

        public async Task<IEnumerable<UangBangunanResponse>> AddUangBangunan(UangBangunanAddRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<UangBangunanResponse> DataUangBangunan = null;

                    NamaConfigPembayaranRequest model = new NamaConfigPembayaranRequest();
                    model.NamaPembayaran = parameter.NamaPembayaran;
                    var dataConfig = await _dataConfigPembayaranService.GetNamaConfigPembayaran(model, cancellationToken);
                    if (dataConfig != null) {
                        foreach (var data in dataConfig)
                        {
                            parameter.NilaiUangBangunan = data.NilaiPembayaran;
                        }
                    } else {
                        return DataUangBangunan;
                    }


                    try
                    {
                        parameter.TanggalBuat = DateTime.Now;
                        DataUangBangunan = await connection.QueryAsync<UangBangunanResponse>(new CommandDefinition("sp_AddUangBangunan", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataUangBangunan, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "UangBangunan";
                        logError.NamaAction = "AddUangBangunan";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataUangBangunan;
                }

            }
        }

        public async Task<IEnumerable<UangBangunanResponse>> EditUangBangunan(UangBangunanUpdateRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<UangBangunanResponse> DataUangBangunan = null;

                    NamaConfigPembayaranRequest model = new NamaConfigPembayaranRequest();
                    model.NamaPembayaran = parameter.NamaPembayaran;
                    var dataConfig = await _dataConfigPembayaranService.GetNamaConfigPembayaran(model, cancellationToken);
                    if (dataConfig != null)
                    {
                        foreach (var data in dataConfig)
                        {
                            parameter.NilaiUangBangunan = data.NilaiPembayaran;
                        }
                    }
                    else
                    {
                        return DataUangBangunan;
                    }

                    try
                    {
                        parameter.TanggalPerbarui = DateTime.Now;
                        DataUangBangunan = await connection.QueryAsync<UangBangunanResponse>(new CommandDefinition("sp_EditUangBangunan", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataUangBangunan, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "UangBangunan";
                        logError.NamaAction = "EditUangBangunan";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataUangBangunan;
                }

            }
        }

        public async Task<int> DeleteUangBangunan(long Id, CancellationToken cancellationToken)
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
                        resultData = await connection.ExecuteAsync(new CommandDefinition("sp_DeleteUangBangunan", Id, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Commit();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "UangBangunan";
                        logError.NamaAction = "DeleteUangBangunan";
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
