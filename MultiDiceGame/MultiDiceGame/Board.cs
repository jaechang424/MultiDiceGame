using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDiceGame
{
    class Board
    {
        public static int[][] Map { get; set; } // board 
        public static int BlockSize { get; set; } = 60; // board
        public static int MapRow { get; set; } = 15; // board
        public static int MapCol { get; set; } = 18; // board

        static Board()
        {
            Map = new int[MapRow][];
            for (int i = 0; i < Map.Length; i++)
            {
                Map[i] = new int[MapCol];
            }
            LoadMap();
        }

        public static void LoadMap()
        {
            SetMap(Map[0], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            SetMap(Map[1], 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0);
            SetMap(Map[2], 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            SetMap(Map[3], 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0);
            SetMap(Map[4], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0);
            SetMap(Map[5], 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0);
            SetMap(Map[6], 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0);
            SetMap(Map[7], 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0);
            SetMap(Map[8], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0);
            SetMap(Map[9], 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0);
            SetMap(Map[10], 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            SetMap(Map[11], 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0);
            SetMap(Map[12], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0);
            SetMap(Map[13], 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0);
            SetMap(Map[14], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        public static void SetMap(int[] map, int a0, int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14, int a15, int a16, int a17)
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
            map[16] = a16;
            map[17] = a17;
        }
    }
}
