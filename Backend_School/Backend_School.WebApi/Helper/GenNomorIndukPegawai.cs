using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using Backend_School.WebApi.Services.Interface;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading;

namespace Backend_School.WebApi.Helper
{
    public class GenNomorIndukPegawai
    {
        public static string NomorInduk (string Connection, ILogErrorService _logErrorService, CancellationToken cancellationToken)
        {
            string Nomor = DateTime.Now.ToString("yyyyMMdd").Substring(0,6);
            string resultNomorInduk = "";

            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(Connection))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        MySqlCommand sqlComm = new MySqlCommand();
                        sqlComm.Transaction = transaction;
                        sqlComm.Connection = connection;
                        sqlComm.CommandText = "sp_CheckNomorIndukPegawai '" + Nomor + "' ";

                        MySqlDataReader reader = sqlComm.ExecuteReader();
                        if(reader.HasRows) {
                            while(reader.Read())
                            {
                                resultNomorInduk = (Convert.ToInt64(reader["NomorIndukPegawai"].ToString()) + 1).ToString();
                            }
                        }
                        else {
                            resultNomorInduk = Nomor + "01";
                        }

                        reader.Close();
                        reader.Dispose();
                        sqlComm.Dispose();
                        transaction.Dispose();

                    }
                    catch (Exception ex)
                    {
                        transaction.Dispose();
                        LogErrorRequest logError = new LogErrorRequest();
                        logError.NamaService = "GenNomorIndukPegawai";
                        logError.NamaAction = "NomorInduk";
                        logError.ErrorDeskripsi = ex.Message;
                        logError.TanggalError = DateTime.Now;
                        var result = _logErrorService.AddLogError(logError, cancellationToken);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return resultNomorInduk;
        }
    }
}
