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
        Task task;

        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            iPlayer = new Player();
            uPlayer = new Player();

            Client.Receive(CallBackClient);

            if (Player.User == User.Server)
            {
                Text = "Server";
                foreach (var client in Server.Clients)
                {
                    Server.Receive(client, CallBackServer);
                }
                for (int i = 0; i < Server.Clients.Count; i++)
                {
                    Server.SendToClient(Server.Clients[i], $"${i}");
                }
            }
            else
            {
                Text = "Client";               
            }            

            if (Player.User == User.Server)
            {
                Thread thread = new Thread(() =>
                {
                    Thread.Sleep(1000);                 
                    int[] orderValues = Game.SelectOrder();
                    if (orderValues[0] == 0)
                    {                       
                        Server.SendToClient(Server.Clients[0], "#first");
                        Server.SendToClient(Server.Clients[1], "#second");
                    }
                    else
                    {
                        Server.SendToClient(Server.Clients[0], "#second");
                        Server.SendToClient(Server.Clients[1], "#first");
                    }
                });
                thread.Start();
            }                   
        }

        // 서버에서 데이터를 받으면 호출할 콜백함수
        private void CallBackServer(string RcvMsg)
        {
            string[] msgs = RcvMsg.Split('/');
            string msg = msgs[0];
            Server.Id = int.Parse(msgs[msgs.Length - 1]);

            if (msg == "#btn_rollDice_Click")
            {
                // 주사위 랜덤값 미리 정하기
                Dice.Spots = new int[Dice.RollCount];
                Random rand = new Random();
                msg = string.Empty;
                for (int i = 0; i < Dice.Spots.Length; i++)
                {
                    //Dice.Spots[i] = rand.Next(1, 7); // 1 ~ 6
                    msg += "/" + rand.Next(1, 7); // 1 ~ 6
                }
                
                for (int i = 0; i < Server.Clients.Count; i++)
                {
                    if (Server.Id == i)
                    {
                        Server.SendToClient(Server.Clients[i], "#btn_rollDice_Click#I" + msg);
                    }
                    else
                    {
                        Server.SendToClient(Server.Clients[i], "#btn_rollDice_Click#U" + msg);
                    }
                }               
            }
        }

        // 클라이언트에서 데이터를 받으면 호출할 콜백함수
        private void CallBackClient(string RcvMsg)
        {
            // 누구인지 설정
            Player.Who = Who.U;

            string[] msgs = RcvMsg.Split('/');
            string msg = msgs[0];
            
            if (msg.IndexOf('$') == 0) // $가 인덱스 0번째에서 발견 되었을 경우
            {
                Client.Id = int.Parse(msg[1].ToString());
            }
            else if (msg == "#first")
            {
                btn_rollDice.Enabled = true;
                lbl_turn.Text = "내 턴";
            }
            else if (msg == "#second")
            {
                btn_rollDice.Enabled = false;
                lbl_turn.Text = "상대 턴";
            }
            else if (msg.IndexOf("#btn_rollDice_Click") == 0)
            {
                if (msg == "#btn_rollDice_Click#I")
                    Player.Who = Who.I;
                else
                    Player.Who = Who.U;

                Dice.Spots = new int[msgs.Length - 1];
                for (int i = 0; i < Dice.Spots.Length; i++)
                {
                    Dice.Spots[i] = int.Parse(msgs[i + 1]);
                }
                Thread thread = new Thread(Start_btn_rollDice_Click);
                thread.Start();
            }
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Dispose();
        }

        // 주사위 굴리기 버튼 클릭
        private void btn_rollDice_Click(object sender, EventArgs e)
        {          
            // 주사위 굴리기 버튼 클릭에 대한 정보를 전송
            Client.SendToServer("#btn_rollDice_Click");
        }

        // 주사위 굴리기 버튼이 클릭되었을 때 실행 할 쓰레드
        private void Start_btn_rollDice_Click()
        {
            // 주사위 굴리기 버튼을 사용 불가로 함
            // 다른 쓰레드에서 컨트롤에 접근 시 크로스 스레드 에러 발생에 대한 대비
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    btn_rollDice.Enabled = false;
                }));
            }
            else
            {
                btn_rollDice.Enabled = false;
            }

            // 주사위를 굴림
            Dice.Roll(ChangeDiceImage);
            // 캐릭터를 움직임
            if (Player.Who == Who.I)
            {
                iPlayer.Move(CallBackInvalidate);
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        lbl_turn.Text = "상대 턴";
                    }));
                }
                else
                {
                    lbl_turn.Text = "상대 턴";
                }
            }
            else
            {
                uPlayer.Move(CallBackInvalidate);
                // 주사위 굴리기 버튼을 사용 가능하게 함
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        btn_rollDice.Enabled = true;
                        lbl_turn.Text = "내 턴";
                    }));
                }
                else
                {
                    btn_rollDice.Enabled = true;
                    lbl_turn.Text = "내 턴";
                }
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
