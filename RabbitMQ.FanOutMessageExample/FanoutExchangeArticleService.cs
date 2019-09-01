using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.FanOutMessageExample
{
    public class FanoutExchangeArticleService
    {
        private static readonly string _queueArticleService = "cingozr.articleservice";

        public FanoutExchangeArticleService()
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
                    Console.WriteLine($"{_queueArticleService} uzerinden alinan mesaj : {message}");
                };
                channel.BasicConsume(_queueArticleService, false, consumer);
            }
        }
    }
}
