using System;

namespace ExampleApp
{
    class Program
    {
        private static readonly string queueName = "TEST";
        private static Publisher _publisher;
        private static Consumer _consumer;
        static void Main(string[] args)
        {
            _publisher = new Publisher(queueName, "Merhaba, bu bir test mesajdir. RabbitMQ TEST");
            _consumer = new Consumer(queueName);
        }
    }
}
