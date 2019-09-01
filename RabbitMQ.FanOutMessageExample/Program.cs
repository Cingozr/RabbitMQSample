using RabbitMQ.Client;
using RabbitMQ.Common;
using System;
using System.Text;

namespace RabbitMQ.FanOutMessageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new FanoutExchangePublisher();
            _ = new FanoutExchangeUserService();
            _ = new FanoutExchangeArticleService();

            Console.ReadLine();

        }
    }
}
