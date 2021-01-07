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
        Timer rollDiceTimer, moveCharTimer;

        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            iPlayer = new Player();
            uPlayer = new Player();
            
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
            RollDice();
        }

        private void RollDice()
        {
            rollDiceTimer = new Timer();
            rollDiceTimer.Tick += RollDiceTimer_Tick;
            rollDiceTimer.Interval = 90;
            rollDiceTimer.Start();
        }

        private void RollDiceTimer_Tick(object sender, EventArgs e)
        {
            if (Game.RollVal < 20)
            {
                Game.RollVal++;
                Random rand = new Random();
                Game.DiceVal = rand.Next(6) + 1;
                pbox_dice.Image = Game.DiceImg[Game.DiceVal - 1];
            }
            else
            {
                Game.RollVal = 0;
                rollDiceTimer.Stop();
                //btn_rollDice.Enabled = true;
                MoveCharacter();
            }
        }

        private void MoveCharacter()
        {
            moveCharTimer = new Timer();
            moveCharTimer.Tick += MoveCharTimer_Tick;
            moveCharTimer.Interval = 200;
            moveCharTimer.Start();
            iPlayer.IsShortPath = true;
        }

        private void MoveCharTimer_Tick(object sender, EventArgs e)
        {
            if (Game.DiceVal > 0)
            {
                Game.DiceVal--;
                if (Game.Map[iPlayer.Y - 1][iPlayer.X] == 1 && iPlayer.IsShortPath)
                {
                    iPlayer.Y--;
                    iPlayer.IsShortPath = false;
                }
                else if (Game.Map[iPlayer.Y - 1][iPlayer.X] == 1 && Game.Map[iPlayer.Y][iPlayer.X - 1] == 0 && Game.Map[iPlayer.Y][iPlayer.X + 1] == 0)
                {

                }
                else if (iPlayer.Direction == Directions.Left)
                {
                    if (iPlayer.X > 0 && iPlayer.X <= 15)
                    {
                        iPlayer.X--;
                    }
                    else if (iPlayer.X == 0 && Game.Map[iPlayer.Y - 1][iPlayer.X] == 1)
                    {
                        iPlayer.Y--;
                    }
                    else
                    {
                        iPlayer.Direction = Directions.Right;
                        Game.DiceVal++;
                    }
                }
                else
                {
                    if (iPlayer.X >= 0 && iPlayer.X < 15)
                    {
                        iPlayer.X++;
                    }
                    else if (iPlayer.X == 15 && Game.Map[iPlayer.Y - 1][iPlayer.X] == 1)
                    {
                        iPlayer.Y--;
                    }
                    else
                    {
                        iPlayer.Direction = Directions.Left;
                        Game.DiceVal++;
                    }
                }
                Invalidate();
            }
            else
            {
                moveCharTimer.Stop();
                btn_rollDice.Enabled = true;
            }
        }

        private void FormGame_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Game.Map.Length; i++)
            {
                for (int j = 0; j < Game.Map[i].Length; j++)
                {
                    if (Game.Map[i][j] == 1)
                    {
                        e.Graphics.FillRectangle(Brushes.Green, 40 + j * Game.BlockSize, 40 + i * Game.BlockSize, Game.BlockSize, Game.BlockSize);
                        e.Graphics.DrawRectangle(Pens.Black, 40 + j * Game.BlockSize, 40 + i * Game.BlockSize, Game.BlockSize, Game.BlockSize);
                    }
                }
            }
            e.Graphics.DrawImage(Game.CharImg[0], 50 + iPlayer.X * Game.BlockSize, 40 + iPlayer.Y * Game.BlockSize, 40, 40);
        }
    }
}
