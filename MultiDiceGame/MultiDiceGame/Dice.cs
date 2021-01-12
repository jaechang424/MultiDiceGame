using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiDiceGame
{
    class Dice
    {
        public static int RollValue { get; set; } // dice
        public static int RollCount { get; set; } = 10; // dice
        public static int Spot { get; set; } // dice
        public static int[] Spots { get; set; }

        public static Bitmap[] Image { get; set; } // dice                

        static Dice()
        {
            Image = new Bitmap[6];
            for (int i = 0; i < Image.Length; i++)
            {
                Image[i] = new Bitmap($@"Image/주사위{i + 1}.png");
            }
        }

        // 주사위를 굴림
        public static void Roll(Action<Bitmap> ChangeDiceImage)
        {
            for (int i = 0; i < RollCount; i++)
            {
                Spot = Spots[i];
                ChangeDiceImage(Image[Spot - 1]);
                Thread.Sleep(60);
            }
        }       
    }
}
