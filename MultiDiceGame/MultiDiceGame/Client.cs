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
        public static void ConnectServer()
        {
            // 소켓 객체 생성 (TCP 소켓)
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 서버에 연결
            var ep = new IPEndPoint(IPAddress.Loopback, 14150);

            try
            {
                client.Connect(ep);
                MessageBox.Show("연결성공");
            }
            catch (SocketException)
            {
                MessageBox.Show("연결실패");
            }
        }

        public static void Close()
        {
            if (client != null)
                client.Close();
        }
    }
}
