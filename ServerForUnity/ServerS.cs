using ServerForUnity.Core;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerForUnity
{
    class ServerS
    {
        private const string Ip = "127.0.0.1";
        private const int PortTcp = 5000;
        private static bool _isStart;
        private static ListBox _listBox;
        static Server server; // сервер
        static Thread listenThread; // потока для прослушивания
            
            //private Thread _thread;
            //private static ManualResetEvent manualResetEvent;
            //public ServerS()
            //{
            //    _isStart = false;
            //    _tcpEndPoint = new IPEndPoint(IPAddress.Parse(Ip), PortTcp);
            //    _tcpSocked = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //}

            public void StopServer()
        {
            //manualResetEvent.Reset();
            server.Disconnect();
            _isStart = false;
            _listBox.Items.Add("ServerS is Stoped");
        }

        public void StartServer(ListBox listBox)
        {

            _listBox = listBox;
            _listBox.Items.Add("Starting the ServerS...");

            try
            {
                server = new Server();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start(); //старт потока
                _isStart = true;
            }
            catch (Exception ex)
            {
                server.Disconnect();
                AddMassege(ex.Message);
                _isStart = false;
            }
            //_listBox.Items.Add("The server is running");
            


            //manualResetEvent = new ManualResetEvent( true );
            //_thread = new Thread(StartListener);
            //_thread.Start(listBox);          
        }

        static void AddMassege(string newText)
        {
            if (_listBox.InvokeRequired) _listBox.Invoke(new Action<string>((s) => _listBox.Items.Add(s)), newText);
            else _listBox.Items.Add(newText);
        }

        private static void StartListener(object list)
        {
            //while (true)
            //{
            //    manualResetEvent.WaitOne();
            //    Thread.Sleep( 3000 );
            //    AddMassege("Цикл");
            //}
        }
    }
}
