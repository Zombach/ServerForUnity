using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerForUnity.Core;

namespace ServerForUnity
{
    public partial class MainForm : Form
    {
        private bool _isStarted = false;
        private Singleton _singleton = Singleton.GetSingleton();

        public MainForm()
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
    }
}
