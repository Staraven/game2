using System;
using ConsoleGameEngine.Interface;
using ConsoleGameEngine.Library.Concrete.Engine;
using ConsoleGameEngine.Library.Concrete.Game;
using ConsoleGameEngine.Library.Interface.Game;

namespace ConsoleGameEngine.Concrete
{
    public class Player : GameObject, IPlayer
    {
        public override int X { get; set; } = 0;

        public override int Y { get; set; } = 1;

        public override int Width { get; set; } = 3;

        public override int Height { get; set; } = 2;

        // // private char[,] spriteIdle = new char[,]
        // // {
        // //     { '\0', '^', '\0' },
        // //     { '/', '-', '\\' },
        // // };
        private char[,] spriteIdle = new char[,]
        {
            { 'M' }
        };

        public override Sprite[] Sprites
        {
            get
            {
                return new Sprite[]
                {
                    new Sprite(this.spriteIdle, this.X, this.Y)
                };
            }
        }

        public Player(Map map) : base(map)
        {
        }

        public override void OnKeyPressed(ConsoleKey key)
        {
            if (key == ConsoleKey.RightArrow)
            {
                if (this.Move(1, 0) && this.ScreenX >= this.Map.Width / 2)
                {
                    this.Map.CameraX = Math.Min(this.Map.CameraX + 1, 20);
                }
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                if (this.Move(-1, 0) && this.ScreenX <= 17)
                {
                    this.Map.CameraX = Math.Max(this.Map.CameraX - 1, 0);
                }
            }
            else if (key == ConsoleKey.UpArrow)
            {
                this.Move(0, 1);
            }
            else if (key == ConsoleKey.DownArrow)
            {
                this.Move(0, -1);
            }

            this.Map.GameEngine.Log($"Player X: {this.X}, Y: {this.Y}");
        }
    }
}