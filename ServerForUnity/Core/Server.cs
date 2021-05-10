using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ServerForUnity.Core.Interface;

namespace ServerForUnity.Core
{
    public class Server
    {
        /// <summary>
        /// Сервер для прослушивания
        /// </summary>
        private TcpListener _tcpListener;

        private List<AbstractClient> _clients;
        public List<Thread> Threads;
        public Server()
        {
            _clients = new List<AbstractClient>();
            Threads = new List<Thread>();
        }

        public void AddConnection(AbstractClient abstractClient)
        {
            _clients.Add(abstractClient);
            // создать файл по пути path предварительно
        }

        protected internal void RemoveConnection(string id)
        {

            // получаем по id закрытое подключение
            AbstractClient abstractClient = _clients.FirstOrDefault(c => c.Id == id);
            // и удаляем его из списка подключений
            if (abstractClient != null)
            {
                _clients.Remove(abstractClient);
            }
        }

        // прослушивание входящих подключений
        protected internal void Listen()
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Any, 8888);
                _tcpListener.Start();
                Console.WriteLine("===============");
                Console.WriteLine("Сервер запущен. Ожидание подключений...");
                Console.WriteLine("===============");

                while (true)
                {
                    TcpClient tcpClient = _tcpListener.AcceptTcpClient();

                    User user = new User(tcpClient, this);
                    Thread thread = new Thread(new ThreadStart(user.Process));
                    thread.Start();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Disconnect();
            }
        }

        private void Log(string v)
        {
            throw new NotImplementedException();
        }
        // трансляция сообщения подключенным клиентам
        public void BroadcastMessage(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < _clients.Count; i++)
            {
                if (_clients[i].Id != id) // если id клиента не равно id отправляющего
                {
                    _clients[i].NetworkStream.Write(data, 0, data.Length); //передача данных
                }
            }
        }
        // отключение всех клиентов
        private void Disconnect()
        {
            _tcpListener.Stop(); //остановка сервера

            for (int i = 0; i < _clients.Count; i++)
            {
                _clients[i].Close(); //отключение клиента
        
            }
            Environment.Exit(0); //завершение процесса
        
        }
    }
}