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


    public class SPPService : ISPPService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly IDataConfigPembayaranService _dataConfigPembayaranService;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "SPP";
        public SPPService(IConfiguration Configuration, IDataConfigPembayaranService dataConfigPembayaranService, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _dataConfigPembayaranService = dataConfigPembayaranService;
            _logErrorService = logErrorService;
        }

        public async Task<IEnumerable<SPPResponse>> GetSPPSearch(SearchSPPRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<SPPResponse> DataSPP = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataSPP = await connection.QueryAsync<SPPResponse>(new CommandDefinition("sp_GetSPPSearch", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "SPP";
                    logError.NamaAction = "GetSPPSearch";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataSPP;
            }
        }

        public async Task<IEnumerable<SPPResponse>> CheckAddSPP(CheckSPPRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<SPPResponse> DataSPP = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataSPP = await connection.QueryAsync<SPPResponse>(new CommandDefinition("sp_CheckAddSPP", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "SPP";
                    logError.NamaAction = "CheckAddSPP";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataSPP;
            }
        }

        public async Task<IEnumerable<BulanResponse>> CheckBulanSPPSiswa(CheckSPPRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<BulanResponse> DataBulanSPP = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataBulanSPP = await connection.QueryAsync<BulanResponse>(new CommandDefinition("sp_CheckBulanSPPSiswa", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "SPP";
                    logError.NamaAction = "CheckBulanSPPSiswa";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataBulanSPP;
            }
        }

        public async Task<IEnumerable<SPPResponse>> AddSPP(SPPAddRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<SPPResponse> DataSPP = null;

                    NamaConfigPembayaranRequest model = new NamaConfigPembayaranRequest();
                    model.NamaPembayaran = parameter.NamaPembayaran;
                    var dataConfig = await _dataConfigPembayaranService.GetNamaConfigPembayaran(model, cancellationToken);
                    if (dataConfig != null) {
                        foreach (var data in dataConfig)
                        {
                            parameter.NilaiSPP = data.NilaiPembayaran;
                        }
                    } else {
                        return DataSPP;
                    }

                    try
                    {
                        parameter.TanggalBuat = DateTime.Now;
                        DataSPP = await connection.QueryAsync<SPPResponse>(new CommandDefinition("sp_AddSPP", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataSPP, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "SPP";
                        logError.NamaAction = "AddSPP";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataSPP;
                }


            }
        }

        public async Task<IEnumerable<SPPResponse>> EditSPP(SPPUpdateRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<SPPResponse> DataSPP = null;

                    NamaConfigPembayaranRequest model = new NamaConfigPembayaranRequest();
                    model.NamaPembayaran = parameter.NamaPembayaran;
                    var dataConfig = await _dataConfigPembayaranService.GetNamaConfigPembayaran(model, cancellationToken);
                    if (dataConfig != null) {
                        foreach (var data in dataConfig)
                        {
                            parameter.NilaiSPP = data.NilaiPembayaran;
                        }
                    } else {
                        return DataSPP;
                    }

                    try
                    {
                        parameter.TanggalPerbarui = DateTime.Now;
                        DataSPP = await connection.QueryAsync<SPPResponse>(new CommandDefinition("sp_EditSPP", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataSPP, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "SPP";
                        logError.NamaAction = "EditSPP";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataSPP;
                }


            }
        }

        public async Task<int> DeleteSPP(long Id, CancellationToken cancellationToken)
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
                        resultData = await connection.ExecuteAsync(new CommandDefinition("sp_DeleteSPP", Id, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "SPP";
                        logError.NamaAction = "DeleteSPP";
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
