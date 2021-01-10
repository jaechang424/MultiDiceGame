using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiDiceGame
{
    public enum Direction { Left, Right, Up, Down }
    public enum Who { I, U }
    public enum User { Server, Client }
    class Player
    {
        public static User User { get; set; }
        public static Who Who { get; set; }
        public static int Count { get; set; } = 2;
        public static Bitmap[] Image { get; set; } // Player        
        public int X { get; set; }
        public int Y { get; set; }   
        public Direction Direction { get; set; }
        public Direction BeforeDirection { get; set; }
        public bool IsShortPath { get; set; }

        public Player()
        {
            Image = new Bitmap[2];
            if (User == User.Server)
            {
                Image[0] = new Bitmap($@"Image/햄토리.png");
                Image[1] = new Bitmap($@"Image/리본.png");
            }
            else
            {
                Image[0] = new Bitmap($@"Image/리본.png");
                Image[1] = new Bitmap($@"Image/햄토리.png");
            }
            X = 1;
            Y = 13;
            Direction = Direction.Right;
        }

        // 캐릭터를 움직임
        public void Move(Action Invalidate)
        {
            IsShortPath = true;
            for (int i = 0; i < Dice.Spot; i++)
            {
                int up = Board.Map[Y - 1][X];
                int left = Board.Map[Y][X - 1];
                int right = Board.Map[Y][X + 1];

                if (up == 1 && left == 0 && Direction == Direction.Left)
                {
                    Y--;
                    if (Direction == Direction.Left || Direction == Direction.Right)
                    {
                        BeforeDirection = Direction;
                        Direction = Direction.Up;
                    }
                }
                else if (up == 1 && right == 0 && Direction == Direction.Right)
                {
                    Y--;
                    if (Direction == Direction.Left || Direction == Direction.Right)
                    {
                        BeforeDirection = Direction;
                        Direction = Direction.Up;
                    }
                }
                else if (up == 1 && X > 0 && X < Board.MapCol - 1 && IsShortPath)
                {
                    Y--;

                    if (Direction == Direction.Left || Direction == Direction.Right)
                    {
                        BeforeDirection = Direction;
                        Direction = Direction.Up;
                    }
                }
                else if (up == 1 && Direction == Direction.Up)
                {
                    Y--;
                }
                else
                {
                    if (Direction == Direction.Up || Direction == Direction.Down)
                    {
                        var temp = Direction;
                        Direction = BeforeDirection;
                        BeforeDirection = temp;

                        if (Direction == Direction.Left)
                            Direction = Direction.Right;
                        else
                            Direction = Direction.Left;
                    }

                    if (Direction == Direction.Left)
                    {
                        if (left != 0)
                        {
                            X--;
                        }
                    }
                    else
                    {
                        if (right != 0)
                        {
                            X++;
                        }
                    }
                }
                Thread.Sleep(100);
                IsShortPath = false;
                Invalidate();
            }
        }       
    }
}
