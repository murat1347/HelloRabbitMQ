using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://srkkvjpy:6rvSFvPpimqp1NSStne5UFFVDG7dzhr9@sparrow.rmq.cloudamqp.com/srkkvjpy");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();
//channel.QueueDeclare("Hello queue", true, false, false);

var consumer = new EventingBasicConsumer(channel);
channel.BasicConsume("Hello queue",true,consumer);


consumer.Received += Consumer_Received;

void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    var message = Encoding.UTF8.GetString(e.Body.ToArray());
    Console.WriteLine("Gelen Mesaj : "+ message);
}

Console.ReadLine();