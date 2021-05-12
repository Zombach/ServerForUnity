using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ServerForUnity.Core.Clients;

namespace ServerForUnity.Core.Servers
{
    public class Server
    {
        /// <summary>
        /// Сервер для прослушивания
        /// </summary>
        private TcpListener _tcpListener;

        private ListBox _listBox;
        //private bool _isStart = false;
        private readonly List<AbstractClient> _clients;

        private Thread _thread;
        //private List<Thread> _threads { get; }

        public Server()
        {
            _clients = new List<AbstractClient>();
        //    _threads = new List<Thread>();
        }

        public void StopServer()
        {
            //manualResetEvent.Reset();
            this.Disconnect();
        //    _isStart = false;
            _listBox.Items.Add("Server is Stopped");
        }

        public void StartServer(ListBox listBox)
        {

            _listBox = listBox;
            _listBox.Items.Add("Starting the Server...");

            try
            {
                _thread = new Thread(this.Listen);
                _thread.Start(); //старт потока
         //       _isStart = true;
            }
            catch (Exception ex)
            {
                this.Disconnect();
                AddMessage(ex.Message);
         //       _isStart = false;
            }
        }

        public void AddMessage(string newText)
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
        private void Listen()
        {
            Singleton singleton = Singleton.GetSingleton();
            try
            {
                _tcpListener = new TcpListener(IPAddress.Parse(singleton.Ip), singleton.Port);
                _tcpListener.Start();
                AddMessage("===============");
                AddMessage("Сервер запущен. Ожидание подключений...");
                AddMessage("===============");

                while (true)
                {
                    TcpClient tcpClient = _tcpListener.AcceptTcpClient();

                    User user = new User(tcpClient);
                    Thread thread = new Thread(user.Process);
                    thread.Start();
                }

            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
                Disconnect();
            }
        }

       
        // трансляция сообщения подключенным клиентам
        public void BroadcastMessage(string userName, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(userName);
            foreach (AbstractClient client in _clients.Where(client => client.Id != id))
            {
                client.NetworkStream.Write(data, 0, data.Length); //передача данных
            }
        }
        // отключение всех клиентов
        public void Disconnect()
        {
            _tcpListener.Stop(); //остановка сервера

            foreach (AbstractClient client in _clients)
            {
                client.Close(); //отключение клиента
            }
            Environment.Exit(0); //завершение процесса
        
        }
       
    }
}