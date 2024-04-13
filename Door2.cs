using System;
using ConsoleGameEngine.Interface;
using ConsoleGameEngine.Library.Concrete.Engine;
using ConsoleGameEngine.Library.Concrete.Game;
using ConsoleGameEngine.Library.Interface.Game;

namespace ConsoleGameEngine.Concrete
{
    public class Door2 : GameObject, IDoor2
    {
        public override int X { get; set; } = 0;

        public override int Y { get; set; } = 0;

        public override int Width { get; set; } = 1;

        public override int Height { get; set; } = 4;

        public override Sprite[] Sprites
        {
            get
            {
                char[,] sprite = new char[this.Height, this.Width];
                for (int i = 0; i < this.Height; i++)
                {
                    if (i % 2 == 0)
                    {
                        sprite[i, 0] = 'G';
                    }
                    else
                    {
                        sprite[i, 0] = 'G';
                    }
                }

                return new Sprite[]
                {
                    new Sprite(sprite, this.X, this.Y)
                };
            }
        }

        public Door2(Map map) : base(map)
        {
        }

        public override bool OnTriggered(IGameObject gameObject, bool check, int moveX, int moveY)
        {
            if (gameObject is IPlayer)
            {
                return false;
            }

            return true;
        }
    }
}