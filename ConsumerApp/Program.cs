using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var connectionFactory = new ConnectionFactory { HostName = "localhost" };
using var connection = connectionFactory.CreateConnection();

using var channel = connection.CreateModel();
channel.QueueDeclare("letterBox", false, false, false, null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (sender, args) => 
{
    var messageBody = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(messageBody);
    Console.WriteLine($"Message Received : {message}");
};

channel.BasicConsume("letterBox", true, consumer);
Console.ReadKey();