using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using Backend_School.WebApi.RabbitMQ;
using Backend_School.WebApi.Services.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Services
{
    public class SiswaServices : ISiswaService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public string routingKey = "Siswa";
        public SiswaServices(IConfiguration Configuration, IMessageProducer MessageProducer, ILogErrorService logErrorService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _logErrorService = logErrorService;
        }

        public async Task<IEnumerable<SiswaResponse>> GetSiswaSearch(SearchSiswaRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<SiswaResponse> DataSiswa = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataSiswa = await connection.QueryAsync<SiswaResponse>(new CommandDefinition("sp_GetSiswaSearch", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "Siswa";
                    logError.NamaAction = "GetSiswaSearch";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataSiswa;
            }
        }

        public async Task<IEnumerable<SiswaResponse>> CheckAddSiswa(CheckSiswaRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                IEnumerable<SiswaResponse> DataSiswa = null;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    DataSiswa = await connection.QueryAsync<SiswaResponse>(new CommandDefinition("sp_CheckAddSiswa", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                }
                catch (Exception ex)
                {
                    LogErrorRequest logError = new LogErrorRequest();
                    logError.NamaService = "Siswa";
                    logError.NamaAction = "CheckAddSiswa";
                    logError.ErrorDeskripsi = ex.Message;
                    logError.TanggalError = DateTime.Now;
                    var result = _logErrorService.AddLogError(logError, cancellationToken);
                }

                return DataSiswa;
            }
        }

        public async Task<string> GenerateNomorIndukSiswa(CancellationToken cancellationToken)
        {
            string Nomor = DateTime.Now.ToString("yyyyMMdd").Substring(0, 6);
            string NomorIndukSiswa = "";

            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        MySqlCommand sqlComm = new MySqlCommand();
                        sqlComm.Transaction = transaction;
                        sqlComm.Connection = connection;
                        sqlComm.CommandText = "sp_CheckNomorIndukSiswa '" + Nomor + "' ";

                        MySqlDataReader reader = sqlComm.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                NomorIndukSiswa = (Convert.ToInt64(reader["NomorIndukSiswa"].ToString()) + 1).ToString();
                            }
                        }
                        else
                        {
                            NomorIndukSiswa = Nomor + "01";
                        }

                        reader.Close();
                        reader.Dispose();
                        sqlComm.Dispose();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Dispose();
                        transaction.Rollback();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Siswa";
                        logError.NamaAction = "GenerateNomorIndukSiswa";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return NomorIndukSiswa;
                }

            }
        }

        public async Task<IEnumerable<SiswaResponse>> AddSiswa(SiswaAddRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<SiswaResponse> DataSiswa = null;
                    try
                    {
                        parameter.TanggalBuat = DateTime.Now;
                        DataSiswa = await connection.QueryAsync<SiswaResponse>(new CommandDefinition("sp_AddSiswa", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataSiswa, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Siswa";
                        logError.NamaAction = "AddSiswa";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataSiswa;
                }

            }
        }

        public async Task<IEnumerable<SiswaResponse>> AddPhotoSiswa(SiswaAddPhotoRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<SiswaResponse> DataSiswa = null;
                    try
                    {
                        parameter.TanggalBuat = DateTime.Now;
                        DataSiswa = await connection.QueryAsync<SiswaResponse>(new CommandDefinition("sp_AddPhotoSiswa", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataSiswa, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Siswa";
                        logError.NamaAction = "AddPhotoSiswa";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataSiswa;
                }

            }
        }

        public async Task<IEnumerable<SiswaResponse>> EditSiswa(SiswaUpdateRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<SiswaResponse> DataSiswa = null;
                    try
                    {
                        parameter.TanggalPerbarui = DateTime.Now;
                        DataSiswa = await connection.QueryAsync<SiswaResponse>(new CommandDefinition("sp_EditSiswa", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataSiswa, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Siswa";
                        logError.NamaAction = "EditSiswa";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataSiswa;
                }

            }
        }

        public async Task<IEnumerable<SiswaResponse>> EditPhotoSiswa(SiswaUpdatePhotoRequest parameter, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    IEnumerable<SiswaResponse> DataSiswa = null;
                    try
                    {
                        parameter.TanggalPerbarui = DateTime.Now;
                        DataSiswa = await connection.QueryAsync<SiswaResponse>(new CommandDefinition("sp_EditPhotoSiswa", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        //_messageProducer.SendMessage(DataSiswa, routingKey, _configuration.GetValue<string>("RabbitMQ:HostName"), _configuration.GetValue<string>("RabbitMQ:UserName"), _configuration.GetValue<string>("RabbitMQ:Password"));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Siswa";
                        logError.NamaAction = "EditPhotoSiswa";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }

                    return DataSiswa;
                }

            }
        }

        public async Task<int> DeleteSiswa(long Id, CancellationToken cancellationToken)
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
                        resultData = await connection.ExecuteAsync(new CommandDefinition("sp_DeleteSiswa", Id, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        transaction.Commit();
                        transaction.Dispose();
                    }
                    catch (Exception ex)
                    {
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "Siswa";
                        logError.NamaAction = "DeleteSiswa";
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
