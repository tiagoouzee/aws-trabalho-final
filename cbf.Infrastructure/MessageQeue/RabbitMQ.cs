using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace cbf.Infrastructure.MessageQeue
{
    public class RabbitMQ
    {
        public void Enviar(string message, string queueName)
        {
            string connectionString = "amqp://user:password@localhost:5672//";

            try
            {
                var factory = new ConnectionFactory()
                {
                    Uri = new Uri(connectionString)
                };

                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                //Declara fila
                channel.QueueDeclare(queue: queueName,
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                //Publica mensagem
                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: Encoding.UTF8.GetBytes(message));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}