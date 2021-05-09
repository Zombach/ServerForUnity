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
    class Server
    {
        private const string Ip = "127.0.0.1";
        private const int PortTcp = 5000;
        //const int portUdp = 5002;
        private static bool _isStart;
        private static EndPoint _tcpEndPoint;
        private static Socket _tcpSocked;
        private static ListBox _listBox;
        private Thread _thread;
        private static string _tmp ="";
        private static ManualResetEvent manualResetEvent;
        public Server()
        {
            _isStart = false;
            _tcpEndPoint = new IPEndPoint(IPAddress.Parse(Ip), PortTcp);
            _tcpSocked = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //_thread = new Thread(new ParameterizedThreadStart(StartListener));
        }

        public void StopServer()
        {
            manualResetEvent.Reset();
            _isStart = false;
            _listBox.Items.Add("Server is Stoped");
        }

        public void StartServer(ListBox listBox)
        {

            _listBox = listBox;            
            _listBox.Items.Add("Starting the Server...");
            _tcpSocked.Bind(_tcpEndPoint);            
            _tcpSocked.Listen(5);
            _listBox.Items.Add("The server is running");
            _isStart = true;

            
            manualResetEvent = new ManualResetEvent( true );
            _thread = new Thread(StartListener);
            _thread.Start(listBox);
            //_thread.Start(listBox);            
        }

        private static void StartListener(object list)
        {
            while (true)
            {
                manualResetEvent.WaitOne();
                TcpListener tcpListener = new TcpListener(IPAddress.Any, 8888);
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                Thread.Sleep( 3000 );
                MessageBox.Show("Цикл");
                //_listBox.Items.Add("Цикл");
            }
            //string tmp = "";
            ////ListBox listBox = (ListBox)list;
            //while (_isStart)
            //{
            //Socket listener = _tcpSocked.Accept();
            //    var buffer = new byte[256];
            //    var size = 0;
            //    var data = new StringBuilder();
            //    if(!_isStart)
            //    {
            //        listener.Shutdown(SocketShutdown.Both);
            //        listener.Close();
            //        tmp = "Server is Stoped";
            //        //listBox.Items.Add("Server is Stoped");
            //        break;
            //    }
            //    do
            //    {                    
            //        size = listener.Receive(buffer);
            //        data.Append(Encoding.UTF8.GetString(buffer, 0, size));
            //        if (!_isStart)
            //        {
            //            listener.Shutdown(SocketShutdown.Both);
            //            listener.Close();
            //            tmp = "Server is Stoped";
            //            //listBox.Items.Add("Server is Stoped");
            //            break;
            //        }
            //    }
            //    while (listener.Available > 0 && _isStart);

            //    tmp = data.ToString();
            //    //listBox.Items.Add(data);

            //    listener.Send(Encoding.UTF8.GetBytes("Success"));

            //    listener.Shutdown(SocketShutdown.Both);
            //    listener.Close();
            //}

            //tmp = "Server is Stoped";
            ////listBox.Items.Add("Server is Stoped");
        }

        private static void test(string tmp)
        {
            _tmp = tmp;
        }
    }
}
