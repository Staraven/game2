using System;
using System.Drawing;

namespace ConsoleGameEngine.Library.Interface.Game
{
    public interface IGravity
    {
        bool GravityDisabled { get; set; }
        public DateTime FallingSetOn { get; set; }
    }
}