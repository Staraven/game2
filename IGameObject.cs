using System;
using System.Drawing;
using ConsoleGameEngine.Library.Concrete.Engine;

namespace ConsoleGameEngine.Library.Interface.Game
{
    public interface IGameObject
    {
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Rectangle Rectangle { get; }
        Sprite[] Sprites { get; }
        public bool IsDisposed { get; set; }

        void OnInitialized();
        void OnDisposed();
        void OnUpdated();
        void OnKeyPressed(ConsoleKey key);
        bool OnTriggered(IGameObject gameObject, bool check, int moveX, int moveY);
    }
}