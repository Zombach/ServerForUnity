using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            //const int portUdp = 5002;
            const int portTcp = 5000;
            #region TCP
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), portTcp);
            var tcpSocked = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Введите сообение:");
            var msg = Console.ReadLine();

            var data = Encoding.UTF8.GetBytes(msg);

            tcpSocked.Connect(tcpEndPoint);

            tcpSocked.Send(data);

            var buffer = new byte[256];
            var size = 0;
            var answer = new StringBuilder();

            do
            {
                size = tcpSocked.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (tcpSocked.Available > 0);
            Console.WriteLine(answer);

            tcpSocked.Shutdown(SocketShutdown.Both);
            tcpSocked.Close();
            Console.ReadLine();
            #endregion
            //var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), portUdp);
            //var udpSocked = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //udpSocked.Bind(udpEndPoint);
            //EndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), 5001);
            //while (true)
            //{
            //    Console.WriteLine("Введите сообщение:");
            //    var msg = Console.ReadLine();

            //    udpSocked.SendTo(Encoding.UTF8.GetBytes(msg), serverEndPoint);

            //    var buffer = new byte[256];
            //    var size = 0;
            //    var data = new StringBuilder();
            //    EndPoint senderEndPoint = new IPEndPoint(IPAddress.Parse(ip), 5001);
            //    do
            //    {
            //        size = udpSocked.ReceiveFrom(buffer, ref senderEndPoint);
            //        data.Append(Encoding.UTF8.GetString(buffer));
            //    }
            //    while (udpSocked.Available > 0);

            //    Console.WriteLine(data);
            //    Console.ReadLine();
            //}

        }
    }
}
