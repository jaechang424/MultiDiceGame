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
        static Game()
        {
                      
        }

        public static int[] SelectOrder()
        {
            Random rand = new Random();
            int[] orderValues = new int[Player.Count];
            for (int i = 0; i < orderValues.Length; i++)
            {
                orderValues[i] = i;
            }

            for (int i = 0; i < orderValues.Length; i++)
            {
                int index = rand.Next(2);
                int temp = orderValues[index];
                orderValues[index] = orderValues[i];
                orderValues[i] = temp;
            }

            return orderValues;
        }
    }
}
