using RabbitMQ.Client;

namespace RabbitMQ.Common
{
    public class RabbitMQService
    {
        private readonly string _hostName = "localhost";
        private readonly int _port = 8081;


        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = _hostName,
                Port = _port
            };
            return connectionFactory.CreateConnection();
        }
    }
}
