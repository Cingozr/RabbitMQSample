using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleApp
{
    public class Publisher
    {
        private readonly RabbitMQService _rabbitMQService;

        public Publisher(string queueName, string message)
        {
            _rabbitMQService = new RabbitMQService();
            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare($"{queueName}",
                       durable: false,
                       exclusive: false,
                       autoDelete: false,
                       arguments: null);

                var messageBody = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: $"{queueName}",
                    basicProperties: null,
                    body: messageBody);

                Console.WriteLine($"{queueName} Queue'suna '{message}' mesaji gonderildi.");
            }
        }
    }
}
