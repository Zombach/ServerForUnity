using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerForUnity
{
    public partial class MainForm : Form
    {
        private bool _isStarted = false;
        private Server _server;

        public MainForm()
        {
            InitializeComponent();
            CreateServer();
        }

        private void CreateServer()
        {
            _server = new Server();
        }

        void StartServer()
        {
            _isStarted = true;
            _server.StartServer(messageList);
            StartButton.Text = @"Stop Server";
        }

        void StopServer()
        {
            _isStarted = false;
            _server.StopServer();
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
