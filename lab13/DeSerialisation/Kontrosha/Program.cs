using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DeSerialisation;

namespace Server
{
    class Program
    {
        
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port); // точка подключения
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // сокет, через который будет устанавливаться соединение


            //Создание объекта
            Kvitant kvi = new Kvitant(11,22,33);

            //Сериализация объекта
            MemoryStream memorystream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memorystream, kvi);
            var message = memorystream.ToArray();

            foreach (var i in message)
                Console.Write($"{i} ");


            var data = message;

            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);
            var buffer = new byte[1000];
            var answer = new StringBuilder();
            var size = 0;

            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (tcpSocket.Available > 0);

            Console.WriteLine(answer.ToString());

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            Console.ReadLine();
        }
    }
}
