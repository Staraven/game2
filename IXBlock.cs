using System;
using ConsoleGameEngine.Library.Interface.Game;

namespace ConsoleGameEngine.Interface
{
    public interface IXBlock : IGameObject
    {
        int BlockType { get; set; }
    }
}