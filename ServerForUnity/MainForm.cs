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
        private ServerS _serverS;

        public MainForm()
        {
            InitializeComponent();
            CreateServer();
        }

        private void CreateServer()
        {
            _serverS = new ServerS();
        }

        void StartServer()
        {
            _isStarted = true;
            _serverS.StartServer(MessageList);
            StartButton.Text = @"Stop ServerS";
        }

        void StopServer()
        {
            _isStarted = false;
            _serverS.StopServer();
            StartButton.Text = @"Start ServerS";
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
