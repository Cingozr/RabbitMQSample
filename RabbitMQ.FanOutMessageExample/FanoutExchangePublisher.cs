using RabbitMQ.Client;
using RabbitMQ.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.FanOutMessageExample
{
    public class FanoutExchangePublisher
    {
        private static readonly string _exchangeName = "cingozr.exchange";
        private static readonly string _queueUserService = "cingozr.userservice";
        private static readonly string _queueArticleService = "cingozr.articleservice";
        private static readonly string _exchangeType = ExchangeType.Fanout;
        private static readonly string _bodyMessage = "Bu mesaj 'Exchange.Fanout' ornek uygulamasini test etmek amaciyla gonderilmistir. Consumer olan servisler bu mesaji almissa eger uygulama basariyla calismaktadir.";

        public FanoutExchangePublisher()
        {
            var rabbitMQService = new RabbitMQService();
            using (IConnection connection = rabbitMQService.GetRabbitMQConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: _exchangeName, type: _exchangeType, durable: true, autoDelete: false, arguments: null);

                channel.QueueDeclare(queue: _queueUserService, durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueDeclare(queue: _queueArticleService, durable: true, exclusive: false, autoDelete: false, arguments: null);

                channel.QueueBind(queue: _queueUserService, exchange: _exchangeName, routingKey: "", arguments: null);
                channel.QueueBind(queue: _queueArticleService, exchange: _exchangeName, routingKey: "", arguments: null);

                var publicationAddress = new PublicationAddress(exchangeType: _exchangeType, exchangeName: _exchangeName, routingKey: "");
                channel.BasicPublish(addr: publicationAddress, basicProperties: null, body: Encoding.UTF8.GetBytes(_bodyMessage));
            }

            Console.WriteLine("Mesaj publish islemi gerceklestirildi.");
        }

    }
}
