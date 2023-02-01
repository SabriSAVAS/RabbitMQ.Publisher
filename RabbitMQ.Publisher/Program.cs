

using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://smlmmjnn:TlCwjz1TsWxldEMzXgkm_wNOnS5-0g6g@hawk.rmq.cloudamqp.com/smlmmjnn");

//Bağlantuyu Aktifleştirme ve Kanal Açma

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queue Oluşturma

channel.QueueDeclare(queue: "example-queue",exclusive:false);

//Queue'ya Mesaj Gönderme

//RabbitMQ Kuyruğa atacağı mesajları byte türünden kabul etmektedir. Haliyle mesajları bizim byte dönüştürmemiz gerekecektir.
//byte[] message = Encoding.UTF8.GetBytes("Merhaba");
//channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message);

for (int i = 0; i < 100; i++)
{
    await Task.Delay(200);
    byte[] message = Encoding.UTF8.GetBytes("Merhaba " + i);
    channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message);
}

Console.Read();
