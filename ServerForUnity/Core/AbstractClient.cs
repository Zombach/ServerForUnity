using ServerForUnity.Core.Interfaces;
using System;
using System.Net.Sockets;
using System.Text;

namespace ServerForUnity.Core
{
    public abstract class AbstractClient :IClient
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public StringBuilder Message { get; set; }
        public NetworkStream NetworkStream { get; set; }
        public TcpClient TcpClient { get; set; }
        protected Singleton Singleton { get; set; }

        protected AbstractClient(TcpClient tcpClient)
        {
            Id = Guid.NewGuid().ToString();
            TcpClient = tcpClient;
            Singleton = Singleton.GetSingleton();
            Singleton.Server.AddConnection(this);
        }
        public virtual void Process()
        {
        }

        //чтение входящего сообщения и преобразование в строку
        public virtual string GetMessage()
        {
            return "";
        }

        // закрытие подключения
        public virtual void Close()
        {
        }
    }
}