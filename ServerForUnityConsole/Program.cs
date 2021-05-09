using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server4Unity
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int portTcp = 5000;
            //const int portUdp = 5001;
            #region TCP
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), portTcp);
            var tcpSocked = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocked.Bind(tcpEndPoint);
            tcpSocked.Listen(5);

            while (true)
            {
                var listener = tcpSocked.Accept();
                var buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();

                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                } 
                while (listener.Available > 0);

                Console.WriteLine(data);

                listener.Send(Encoding.UTF8.GetBytes("Success"));

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
            #endregion
            //while (true)
            //{
            //    var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), portUdp);
            //    var udpSocked = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //    udpSocked.Bind(udpEndPoint);

            //    var buffer = new byte[256];
            //    var size = 0;
            //    var data = new StringBuilder();
            //    EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);
            //    do
            //    {
            //        size = udpSocked.ReceiveFrom(buffer, ref senderEndPoint);
            //        data.Append(Encoding.UTF8.GetString(buffer));
            //    }
            //    while (udpSocked.Available > 0);

            //    udpSocked.SendTo(Encoding.UTF8.GetBytes("Success UDP"), senderEndPoint);
            //}            
        }
    }
}