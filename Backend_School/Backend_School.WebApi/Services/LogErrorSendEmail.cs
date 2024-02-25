using System;
using System.Threading;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Backend_School.WebApi.Services.Interface;
using System.Net.Mail;
using System.Net;

namespace Backend_School.WebApi.Services
{
    public class LogErrorSendEmail : ILogErrorSendEmail
    {
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public string routingKey = "LogErrorSendEmail";

        public LogErrorSendEmail(IConfiguration Configuration, IMessageProducer MessageProducer)
        {
            _configuration = Configuration;
            _messageProducer = MessageProducer;
        }

        public async Task<string> ErrorSendEmail(LogErrorRequest parameter, CancellationToken cancellationToken)
        {
            try
            {
                string EmailFrom = "SupportLogicSoft@gmail.com";
                string EmailTo = "SupportLogicSoft@gmail.com";
                string PasswordEmailFrom = "";

                using (MailMessage mail = new MailMessage(EmailFrom, EmailTo))
                {
                   
                    mail.Subject = "Log Error Apps SIMS";
                    mail.Body = "Nama Service --> " + parameter.NamaService + ", Nama Action --> + " + parameter.NamaAction + ", Error --> " + parameter.ErrorDeskripsi;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(EmailFrom, PasswordEmailFrom);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Timeout = 30000;
                    smtp.Port = 587;
                    smtp.Send(mail);
                }

                return "Success LogErrorSendEmail";
            }
            catch (Exception ex)
            {
                return "Error LogErrorSendEmail --> " + ex.Message;
            }

        }
    }
}
