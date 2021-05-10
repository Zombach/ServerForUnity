using System;
using System.Net.Sockets;
using System.Text;

namespace ServerForUnity.Core
{
    public class User :AbstractClient
    {
        private readonly Server _server;
        public User(TcpClient tcpClient) : base(tcpClient)
        {
            _server = Singleton.Server;
        }

        public override void Process()
        {
            try
            {
                NetworkStream = TcpClient.GetStream();
               
                UserName =$"{GetMessage()}:"; // получаем имя пользователя
                Message = new StringBuilder($"{UserName} входит в чат");
                
                AddMessage(); // посылаем сообщение о входе в чат всем подключенным пользователям
                
                while (true) // в бесконечном цикле получаем сообщения от клиента
                {
                    try
                    {
                        Message = new StringBuilder($"{UserName} {GetMessage()}");
                        AddMessage();
                    }
                    catch
                    {
                        Message = new StringBuilder($"{UserName} покинул чат");
                        AddMessage();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                _server.AddMessage(e.Message);
            }
            finally // в случае выхода из цикла закрываем ресурсы
            {
                _server.RemoveConnection(this.Id);
                Close();
            }
        }

        private void AddMessage()
        {
            _server.AddMessage(Message.ToString());
            _server.BroadcastMessage(UserName, this.Id);
        }

        public override string GetMessage()
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            Message = new StringBuilder();
            do
            {
                int bytes = NetworkStream.Read(data, 0, data.Length);
                Message.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (NetworkStream.DataAvailable);

            return Message.ToString();
        }

        public override void Close()
        {
            NetworkStream?.Close();
            TcpClient?.Close();
        }
    }
}