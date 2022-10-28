// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://srkkvjpy:6rvSFvPpimqp1NSStne5UFFVDG7dzhr9@sparrow.rmq.cloudamqp.com/srkkvjpy");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();
channel.QueueDeclare("Hello queue",true,false,false);

string message = "hello world";

var messageBody = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(string.Empty,"Hello queue",null,messageBody);
Console.WriteLine("Mesajınız gönderilmiştir!");
Console.ReadLine();