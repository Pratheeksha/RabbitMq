using System.Text;
using RabbitMQ.Client;

var connectionFactory = new ConnectionFactory { HostName = "localhost"};
using var connection = connectionFactory.CreateConnection();

using var channel = connection.CreateModel();
channel.QueueDeclare("letterBox",false,false,false,null);

var message = "This is my forst message";
var encodedMessage = Encoding.UTF8.GetBytes(message);
channel.BasicPublish("", "letterBox", null, encodedMessage);//first argument "" means publish to a default exchange

Console.WriteLine($"Published message : {message}");


