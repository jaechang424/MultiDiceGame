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
        Bitmap[] diceImg;
        int sz = 55; // 공간크기
        Timer rollDiceTimer;
        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            iPlayer = new Player();
            uPlayer = new Player();
            diceImg = new Bitmap[6];
            for (int i = 0; i < diceImg.Length; i++)
            {
                diceImg[i] = new Bitmap($@"Image/주사위{i + 1}.png");
            }
            /*Timer t_order = new Timer();
            t_order.Interval = 2000;
            t_order.Tick += t_order_Tick;
            t_order.Start();*/
        }

        private void t_order_Tick(object sender, EventArgs e)
        {
            //int[] orderValues = Game.SelectOrder();
            //Server.SendToClient(orderValues);
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Owner.Show();
            Owner.Dispose();
        }

        private void btn_rollDice_Click(object sender, EventArgs e)
        {
            btn_rollDice.Enabled = false;
            rollDiceTimer = new Timer();
            rollDiceTimer.Tick += RollDiceTimer_Tick;
            rollDiceTimer.Interval = 100;
            rollDiceTimer.Start();
        }

        private void RollDiceTimer_Tick(object sender, EventArgs e)
        {
            if (Game.RollVal < 20)
            {
                Game.RollVal++;
                Random rand = new Random();
                pbox_dice.Image = diceImg[rand.Next(6)];
            }
            else
            {
                Game.RollVal = 0;
                rollDiceTimer.Stop();
                btn_rollDice.Enabled = true;
            }
        }

        private void FormGame_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Game.Map.Length; i++)
            {
                for (int j = 0; j < Game.Map[i].Length; j++)
                {
                    e.Graphics.FillRectangle(Brushes.Green, 50 + j * sz, 50 + i * sz, sz, sz);
                    e.Graphics.DrawRectangle(Pens.Black, 50 + j * sz, 50 + i * sz, sz, sz);
                }
            }
        }
    }
}
