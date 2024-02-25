using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using Backend_School.WebApi.Services.Interface;
using Backend_School.WebApi.RabbitMQ;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using MySqlX.XDevAPI.Common;

namespace Backend_School.WebApi.Services
{

    public class LogErrorService : ILogErrorService
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorSendEmail _logErrorSendEmailService;
        public string routingKey = "LogError";
        public LogErrorService(IConfiguration Configuration, IMessageProducer MessageProducer, ILogErrorSendEmail logErrorSendEmailService)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
            _logErrorSendEmailService = logErrorSendEmailService;
        }

        public async Task<int> AddLogError(LogErrorRequest parameter, CancellationToken cancellationToken)
        {
            int result = 0;
            string resultSendEmail = "";
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection")))
            {
                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        if (connection.State == ConnectionState.Closed) {
                            connection.Open();
                        }

                        parameter.TanggalError = System.DateTime.Now;
                        result = await connection.ExecuteAsync(new CommandDefinition("sp_AddLogError", parameter, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
                        resultSendEmail = await _logErrorSendEmailService.ErrorSendEmail(parameter, cancellationToken);


                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        return 0;
                    }
                }
            }
            
        }

       
    }
}
