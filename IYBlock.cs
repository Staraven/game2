using System;
using ConsoleGameEngine.Library.Interface.Game;

namespace ConsoleGameEngine.Interface
{
    public interface IYBlock : IGameObject
    {
        int BlockType { get; set; }
    }
}