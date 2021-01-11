using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiDiceGame
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            /*FormGame formGame = new FormGame();
            formGame.Owner = this;
            formGame.Show();*/
        }

        private void btn_openServer_Click(object sender, EventArgs e)
        {
            Server.OpenServer();
            Server.AcceptClient(this);
        }

        private void btn_connectServer_Click(object sender, EventArgs e)
        {
            Client.ConnectServer();
            FormGame formGame = new FormGame();
            Player.User = User.Client;
            formGame.Owner = this;
            formGame.Show();
        }

        private void CallBack(string RcvMsg)
        {

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server.Close();
            Client.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.Sleep(2000);
            this.Show();
        }
    }
}
