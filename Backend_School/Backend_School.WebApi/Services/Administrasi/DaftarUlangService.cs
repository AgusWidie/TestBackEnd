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


    public class DaftarUlangService : IDaftarUlangService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly IDataConfigPembayaranService _dataConfigPembayaranService;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "DaftarUlang";
        public DaftarUlangService(IConfiguration Configuration, IDataConfigPembayaranService dataConfigPembayaranService, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _dataConfigPembayaranService = dataConfigPembayaranService;
            _logErrorService = logErrorService;
        }

        public async Task<IEnumerable<DaftarUlangResponse>> GetDaftarUlangSearch(SearchDaftarUlangRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<DaftarUlangResponse> DataDaftarUlang = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataDaftarUlang = await connection.QueryAsync<DaftarUlangResponse>(new CommandDefinition("sp_GetDaftarUlangSearch", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "DaftarUlang";
                    logError.NamaAction = "GetDaftarUlangSearch";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }
                return DataDaftarUlang;
            }
        }

        public async Task<IEnumerable<DaftarUlangResponse>> CheckAddDaftarUlang(CheckDaftarUlangRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<DaftarUlangResponse> DataDaftarUlang = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataDaftarUlang = await connection.QueryAsync<DaftarUlangResponse>(new CommandDefinition("sp_CheckAddDaftarUlang", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "DaftarUlang";
                    logError.NamaAction = "CheckAddDaftarUlang";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }
                return DataDaftarUlang;
            }
        }

        public async Task<IEnumerable<DaftarUlangResponse>> AddDaftarUlang(DaftarUlangAddRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }


                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<DaftarUlangResponse> DataDaftarUlang = null;

                    NamaConfigPembayaranRequest model = new NamaConfigPembayaranRequest();
                    model.NamaPembayaran = parameter.NamaPembayaran;
                    var dataConfig = await _dataConfigPembayaranService.GetNamaConfigPembayaran(model, cancellationToken);
                    if (dataConfig != null) {
                        foreach (var data in dataConfig)
                        {
                            parameter.NilaiDaftarUlang = data.NilaiPembayaran;
                        }
                    } else {

                        return DataDaftarUlang;
                    }

                    try
                    {
                        parameter.Kembalian = parameter.Bayar - parameter.NilaiDaftarUlang;
                        parameter.TanggalBuat = DateTime.Now;
                        DataDaftarUlang = await connection.QueryAsync<DaftarUlangResponse>(new CommandDefinition("sp_AddDaftarUlang", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataDaftarUlang, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Commit();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "DaftarUlang";
                        logError.NamaAction = "AddDaftarUlang";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }
                    return DataDaftarUlang;
                }

            }
        }

        public async Task<IEnumerable<DaftarUlangResponse>> EditDaftarUlang(DaftarUlangUpdateRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<DaftarUlangResponse> DataDaftarUlang = null;

                    NamaConfigPembayaranRequest model = new NamaConfigPembayaranRequest();
                    model.NamaPembayaran = parameter.NamaPembayaran;
                    var dataConfig = await _dataConfigPembayaranService.GetNamaConfigPembayaran(model, cancellationToken);
                    if (dataConfig != null) {
                        foreach (var data in dataConfig)
                        {
                            parameter.NilaiDaftarUlang = data.NilaiPembayaran;
                        }
                    } else {
                        return DataDaftarUlang;
                    }

                    try
                    {
                        parameter.Kembalian = parameter.Bayar - parameter.NilaiDaftarUlang;
                        parameter.TanggalPerbarui = DateTime.Now;
                        DataDaftarUlang = await connection.QueryAsync<DaftarUlangResponse>(new CommandDefinition("sp_EditDaftarUlang", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataDaftarUlang, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Commit();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "DaftarUlang";
                        logError.NamaAction = "EditDaftarUlang";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }
                    return DataDaftarUlang;
                }

            }
        }

        public async Task<int> DeleteDaftarUlang(long Id, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed) {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    int resultData = 0;
                    try
                    {
                        resultData = await connection.ExecuteAsync(new CommandDefinition("sp_DeleteDaftarUlang", Id, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Commit();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "DaftarUlang";
                        logError.NamaAction = "DeleteDaftarUlang";
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
