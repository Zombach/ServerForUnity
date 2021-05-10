using System;
using System.Net.Sockets;
using System.Text;

namespace ServerForUnity.Core
{
    public class User :AbstractClient
    {
        public User(TcpClient tcpClient) : base(tcpClient)
        {
        }

        //public override void Process()
        //{
        //}

        public override string GetMessage()
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = NetworkStream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (NetworkStream.DataAvailable);

            return builder.ToString();
        }

        public override void Close()
        {
            if (NetworkStream != null)
                NetworkStream.Close();
            if (TcpClient != null)
                TcpClient.Close();
        }
    }
}