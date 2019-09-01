using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.FanOutMessageExample
{
    public class FanoutExchangeUserService
    {
        private static readonly string _queueUserService = "cingozr.userservice";
        public FanoutExchangeUserService()
        {
            var rabbitMQService = new RabbitMQService();

            using (IConnection connection = rabbitMQService.GetRabbitMQConnection())
            using (IModel channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    byte[] body = ea.Body;
                    string message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"{_queueUserService} uzerinden alinan mesaj : {message}");
                };
                channel.BasicConsume(_queueUserService, false, consumer);
            }
        }
    }
}
