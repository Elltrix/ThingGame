﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new TriangleWarsGame();
            game.Setup();
            game.Run();
        }
    }
}
