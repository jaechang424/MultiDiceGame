using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiDiceGame
{
    class Game
    {
        public static int[][] Map { get; set; }
        public static int PlayerCount { get; set; } = 2;
        public static int RollVal { get; set; }
        public static int DiceVal { get; set; }
        public static bool IsRolling { get; set; }
        public static int BlockSize { get; set; } = 60;
        public static Bitmap[] DiceImg { get; set; }
        public static Bitmap[] CharImg { get; set; }

        static Game()
        {
            Map = new int[13][];
            for (int i = 0; i < Map.Length; i++)
            {
                Map[i] = new int[16];
            }
            LoadMap();
            DiceImg = new Bitmap[6];
            for (int i = 0; i < DiceImg.Length; i++)
            {
                DiceImg[i] = new Bitmap($@"Image/주사위{i + 1}.png");
            }
            CharImg = new Bitmap[2];
            CharImg[0] = new Bitmap($@"Image/햄토리.png");
            CharImg[1] = new Bitmap($@"Image/리본.png");
        }

        public static void LoadMap()
        {
            SetMap(Map[0],  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            SetMap(Map[1],  1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            SetMap(Map[2],  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            SetMap(Map[3],  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            SetMap(Map[4],  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            SetMap(Map[5],  1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0);
            SetMap(Map[6],  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            SetMap(Map[7],  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            SetMap(Map[8],  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            SetMap(Map[9],  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            SetMap(Map[10], 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            SetMap(Map[11], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            SetMap(Map[12], 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
        }

        public static void SetMap(int[] map, int a0, int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14, int a15)
        {
            map[0] = a0;
            map[1] = a1;
            map[2] = a2;
            map[3] = a3;
            map[4] = a4;
            map[5] = a5;
            map[6] = a6;
            map[7] = a7;
            map[8] = a8;
            map[9] = a9;
            map[10] = a10;
            map[11] = a11;
            map[12] = a12;
            map[13] = a13;
            map[14] = a14;
            map[15] = a15;
        }

        public static int[] SelectOrder()
        {
            Random rand = new Random();
            int[] orderValues = new int[PlayerCount];
            for (int i = 0; i < orderValues.Length; i++)
            {
                orderValues[i] = rand.Next(1, 2);
            }
            return orderValues;
        }
    }
}
