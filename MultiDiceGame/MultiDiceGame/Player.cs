using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDiceGame
{
    public enum Directions { Left, Right, Up, Down }
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int MotionValue { get; set; }     
        public Directions Direction { get; set; }
        public Directions BeforeDirection { get; set; }
        public bool IsShortPath { get; set; }

        public Player()
        {
            X = 0;
            Y = 12;
            Direction = Directions.Right;
        }
    }
}
