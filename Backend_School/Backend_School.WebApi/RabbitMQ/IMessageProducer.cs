using System;

namespace Backend_School.WebApi.RabbitMQ
{
    public interface IMessageProducer
    {
        public void SendMessage<T>(T message, string routingKey, string Hostname, string UserName, string Password);

    }
}
