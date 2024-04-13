using System;
using ConsoleGameEngine.Interface;
using ConsoleGameEngine.Library.Concrete.Engine;
using ConsoleGameEngine.Library.Concrete.Game;
using ConsoleGameEngine.Library.Interface.Game;

namespace ConsoleGameEngine.Concrete
{
    public class YBlock : GameObject, IYBlock
    {
        public int BlockType { get; set; } = 0;
        public override int X { get; set; } = 0;

        public override int Y { get; set; } = 0;

        public override int Width { get; set; } = 1;

        public override int Height { get; set; } = 3;

        private char[,] spriteBlock0 = new char[,]
        {
            { '^' },
            { '|' },
            { 'v' },
        };

        private char[,] spriteBlock1 = new char[,]
        {
            { '*' },
            { '|' },
            { '*' },
        };

        public override Sprite[] Sprites
        {
            get
            {
                if (this.BlockType == 0)
                {
                    return new Sprite[]
                    {
                        new Sprite(this.spriteBlock0, this.X, this.Y)
                    };
                }
                else
                {
                    return new Sprite[]
                    {
                        new Sprite(this.spriteBlock1, this.X, this.Y)
                    };
                }
            }
        }

        public YBlock(Map map) : base(map)
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