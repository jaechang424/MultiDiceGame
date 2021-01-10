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

            if (Player.User == User.Server)
            {
                Text = "Server";
                Server.Receive(CallBack);
            }
            else
            {
                Text = "Client";
                Client.Receive(CallBack);
            }

            if (Player.User == User.Server)
            {
                Thread thread = new Thread(() =>
                {
                    Thread.Sleep(1000);                 
                    int[] orderValues = Game.SelectOrder();
                    if (orderValues[0] == 0)
                    {
                        Server.SendToClient("#server");
                        btn_rollDice.Enabled = true;
                        lbl_turn.Text = "내 턴";
                    }
                    else
                    {
                        Server.SendToClient("#client");
                        lbl_turn.Text = "상대 턴";
                    }
                });
                thread.Start();
            }                   
        }

        // 서버나 클라이언트 에서 데이터를 받으면 호출할 콜백함수
        private void CallBack(string RcvMsg)
        {
            // 누구인지 설정
            Player.Who = Who.U;

            string[] msg = RcvMsg.Split('/');
            if (msg[0] == "#btn_rollDice_Click")
            {
                Dice.Spots = new int[msg.Length - 1];
                for (int i = 0; i < Dice.Spots.Length; i++)
                {
                    Dice.Spots[i] = int.Parse(msg[i + 1]);
                }
                Thread thread = new Thread(Start_btn_rollDice_Click);
                thread.Start();                
            }
            else if (msg[0] == "#server")
            {
                //pbox_dice.Enabled = false;
                lbl_turn.Text = "상대 턴";
            }
            else if (msg[0] == "#client")
            {
                btn_rollDice.Enabled = true;
                lbl_turn.Text = "내 턴";
            }
        }

        private void t_order_Tick(object sender, EventArgs e)
        {
            //int[] orderValues = Game.SelectOrder();
            //Server.SendToClient(orderValues);
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Dispose();
        }

        // 주사위 굴리기 버튼 클릭
        private void btn_rollDice_Click(object sender, EventArgs e)
        {
            // 누구인지 설정
            Player.Who = Who.I;

            // 주사위 랜덤값 미리 정하기
            Dice.Spots = new int[Dice.RollCount];
            Random rand = new Random();
            for (int i = 0; i < Dice.Spots.Length; i++)
            {
                Dice.Spots[i] = rand.Next(1, 7); // 1 ~ 6
            }

            // 스레드로 시작
            Thread thread = new Thread(Start_btn_rollDice_Click);
            thread.Start();

            // 주사위 굴리기 버튼 클릭에 대한 정보를 전송
            string msg = "#btn_rollDice_Click";
            foreach (var v in Dice.Spots)
            {
                msg += "/" + v;
            }
            if (Player.User == User.Server)
                Server.SendToClient(msg);
            else
                Client.SendToServer(msg);
        }

        // 주사위 굴리기 버튼이 클릭되었을 때 실행 할 쓰레드
        private void Start_btn_rollDice_Click()
        {
            // 주사위 굴리기 버튼을 사용 불가로 함
            btn_rollDice.Enabled = false;
           
            // 주사위를 굴림
            Dice.Roll(ChangeDiceImage);
            // 캐릭터를 움직임
            if (Player.Who == Who.I)
            {
                iPlayer.Move(CallBackInvalidate);
            }
            else
            {
                uPlayer.Move(CallBackInvalidate);
                // 주사위 굴리기 버튼을 사용 가능하게 함
                btn_rollDice.Enabled = true;
            }            
        }

        private void ChangeDiceImage(Bitmap image)
        {
            pbox_dice.Image = image;
        }

        private void CallBackInvalidate()
        {
            Invalidate();
        }      

        private void FormGame_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 1; i < Board.Map.Length - 1; i++)
            {
                for (int j = 1; j < Board.Map[i].Length - 1; j++)
                {
                    if (Board.Map[i][j] == 1)
                    {
                        e.Graphics.FillRectangle(Brushes.Green, 40 + (j - 1) * Board.BlockSize, 40 + (i - 1) * Board.BlockSize, Board.BlockSize, Board.BlockSize);
                        e.Graphics.DrawRectangle(Pens.Black, 40 + (j - 1) * Board.BlockSize, 40 + (i - 1) * Board.BlockSize, Board.BlockSize, Board.BlockSize);
                    }
                }
            }
            e.Graphics.DrawImage(Player.Image[1], 50 + (uPlayer.X - 1) * Board.BlockSize, 60 + (uPlayer.Y - 1) * Board.BlockSize, 40, 40);
            e.Graphics.DrawImage(Player.Image[0], 50 + (iPlayer.X - 1) * Board.BlockSize, 40 + (iPlayer.Y - 1) * Board.BlockSize, 40, 40);
        }
    }
}
