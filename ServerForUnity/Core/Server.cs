using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ServerForUnity.Core.Interface;

namespace ServerForUnity.Core
{
    public class Server
    {
        /// <summary>
        /// Сервер для прослушивания
        /// </summary>
        private TcpListener _tcpListener;

        private ListBox _listBox;
        private bool _isStart = false;
        private List<AbstractClient> _clients;

        private Thread _thread;
        public List<Thread> Threads;

        public Server()
        {
            _clients = new List<AbstractClient>();
            Threads = new List<Thread>();
        }

        public void StopServer()
        {
            //manualResetEvent.Reset();
            this.Disconnect();
            _isStart = false;
            _listBox.Items.Add("Server is Stoped");
        }

        public void StartServer(ListBox listBox)
        {

            _listBox = listBox;
            _listBox.Items.Add("Starting the Server...");

            try
            {
                _thread = new Thread(new ThreadStart(this.Listen));
                _thread.Start(); //старт потока
                _isStart = true;
            }
            catch (Exception ex)
            {
                this.Disconnect();
                AddMassege(ex.Message);
                _isStart = false;
            }
        }

        public void AddMassege(string newText)
        {
            if (_listBox.InvokeRequired) _listBox.Invoke(new Action<string>((s) => _listBox.Items.Add(s)), newText);
            else _listBox.Items.Add(newText);
        }

        public void AddConnection(AbstractClient abstractClient)
        {
            _clients.Add(abstractClient);
            // создать файл по пути path предварительно
        }

        public void RemoveConnection(string id)
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
        protected void Listen()
        {
            string ip = "127.0.0.1";
            int port = 8888;
            try
            {
                _tcpListener = new TcpListener(IPAddress.Parse(ip), port);
                _tcpListener.Start();
                AddMassege("===============");
                AddMassege("Сервер запущен. Ожидание подключений...");
                AddMassege("===============");

                while (true)
                {
                    TcpClient tcpClient = _tcpListener.AcceptTcpClient();

                    User user = new User(tcpClient);
                    Thread thread = new Thread(new ThreadStart(user.Process));
                    thread.Start();
                }

            }
            catch (Exception ex)
            {
                AddMassege(ex.Message);
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
        public void Disconnect()
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