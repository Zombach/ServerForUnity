using System;
using System.Windows.Forms;
using ServerForUnity.Core;

namespace ServerForUnity.Forms
{
    public partial class Main : Form
    {
        private bool _isStarted = false;
        private Singleton _singleton = Singleton.GetSingleton();

        public Main()
        {
            InitializeComponent();
            CreateServer();
        }

        private void CreateServer()
        {
            //_serverS = new ServerS();
        }

        void StartServer()
        {
            _isStarted = true;
            _singleton.Server.StartServer(MessageList);
            StartButton.Text = @"Stop Server";
        }

        void StopServer()
        {
            _isStarted = false;
            _singleton.Server.StopServer();
            StartButton.Text = @"Start Server";
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (_isStarted)
                StopServer();
            else
                StartServer();
        }

        private void Menu_Closing(Object sender, FormClosingEventArgs e)
        {
            _singleton.Server.Disconnect();
        }
    }
}
