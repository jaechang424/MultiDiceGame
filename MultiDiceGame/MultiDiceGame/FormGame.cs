using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiDiceGame
{
    public partial class FormGame : Form
    {
        Player iPlayer, uPlayer;
        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            iPlayer = new Player();
            uPlayer = new Player();
            Timer t_order = new Timer();
            t_order.Interval = 2000;
            t_order.Tick += t_order_Tick;
            t_order.Start();
        }

        private void t_order_Tick(object sender, EventArgs e)
        {
            int[] orderValues = Game.SelectOrder();
            Server.SendToClient(orderValues);
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }

        private void FormGame_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Game.Map.Length; i++)
            {
                for (int j = 0; j < Game.Map[i].Length; j++)
                {
                    e.Graphics.FillRectangle(Brushes.Green, 50 + i * 30, 50 + j * 30, 30, 30);
                    e.Graphics.DrawRectangle(Pens.Black, 50 + i * 30, 50 + j * 30, 30, 30);
                }
            }
        }
    }
}
