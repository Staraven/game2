using System;
using ConsoleGameEngine.Interface;
using ConsoleGameEngine.Library.Concrete.Engine;
using ConsoleGameEngine.Library.Concrete.Game;
using ConsoleGameEngine.Library.Interface.Game;

namespace ConsoleGameEngine.Concrete
{
    public class Star : GameObject, IStar
    {
        public override int X { get; set; } = 0;

        public override int Y { get; set; } = 0;

        public override int Width { get; set; } = 1;

        public override int Height { get; set; } = 1;

        private char[,] sprite = new char[,]
        {
            { '?' },
        };

        public override Sprite[] Sprites
        {
            get
            {
                return new Sprite[]
                {
                    new Sprite(this.sprite, this.X, this.Y)
                };
            }
        }

        public IDoor Door { get; set; }

        public Star(Map map) : base(map)
        {
        }

        public override bool OnTriggered(IGameObject gameObject, bool check, int moveX, int moveY)
        {
            if (gameObject is IPlayer)
            {
                this.Map.DisposeGameObject(this.Door);
                this.Map.DisposeGameObject(this);
            }

            return true;
        }
    }
}