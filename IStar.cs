using System;
using ConsoleGameEngine.Library.Interface.Game;

namespace ConsoleGameEngine.Interface
{
    public interface IStar : IGameObject
    {
        IDoor Door { get; set; }
    }
}