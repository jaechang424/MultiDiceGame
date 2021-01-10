using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace MultiDiceGame
{
    class Client
    {
        private static Socket client;
        public static string RcvMsg { get; set; }
        public static void ConnectServer()
        {
            // 소켓 객체 생성 (TCP 소켓)
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 서버에 연결
            var ep = new IPEndPoint(IPAddress.Loopback, 14150);

            try
            {
                client.Connect(ep);
                //MessageBox.Show("연결성공");

            }
            catch (SocketException)
            {
                MessageBox.Show("연결실패");
            }
        }

        public static async void Receive(Action<string> callBack)
        {
            while (true)
            {
                byte[] rcvData = new byte[1000];
                var length = await Task.Factory.FromAsync(
                    client.BeginReceive(rcvData, 0, rcvData.Length, SocketFlags.None, null, null),
                    client.EndReceive);
                RcvMsg = Encoding.UTF8.GetString(rcvData, 0, length);
                callBack(RcvMsg);
            }
        }

        public static async void SendToServer<T>(T _msg)
        {
            // 클라이언트로 데이터를 전송
            dynamic msg = _msg;
            byte[] sendData = Encoding.UTF8.GetBytes(msg);
            await Task.Factory.FromAsync(
                client.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, null, null),
                client.EndSend);
        }

        public static void Close()
        {
            if (client != null)
                client.Close();
        }
    }
}
