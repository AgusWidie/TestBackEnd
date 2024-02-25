using RabbitMQ.Client;
using System;
using System.Text;
using Newtonsoft.Json;

namespace Backend_School.WebApi.RabbitMQ
{
    public class MessageProducer : IMessageProducer
    {
        private IConnection _connection;
        public void SendMessage<T>(T message, string routingKey, string Hostname, string UserName, string Password)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = Hostname,
                    UserName = UserName,
                    Password = Password
                };

                if (_connection == null || !_connection.IsOpen) {
                    _connection = factory.CreateConnection();

                }
                using var channel = _connection.CreateModel();
                channel.QueueDeclare(routingKey, exclusive: false);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: "", routingKey: routingKey, body: body);

                channel.Close();
                _connection.Close();
            }
            catch (InvalidOperationException ex) {


            }
        }
    }
}
