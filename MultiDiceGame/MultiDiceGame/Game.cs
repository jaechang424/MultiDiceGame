using System;
using System.Collections.Generic;
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
        public static bool IsRolling { get; set; }

        static Game()
        {
            Map = new int[13][];
            for (int i = 0; i < Map.Length; i++)
            {
                Map[i] = new int[16];
            }

            LoadMap();
        }

        public static void LoadMap()
        {
            //SetMap(10, 20, 30, 40, 50);
        }

        public static void SetMap(params int[] m)
        {
            /*for (int i = 0; i < m.Length; i++)
            {
                Map[1]
            }*/
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
