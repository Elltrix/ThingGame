﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThingEngine;


namespace TriangleWars
{
    public class TriangleWarsGame : Game
    {
        public override void Setup()
        {
            base.Setup();

            //this.World.Scene.Add(new Triangle(-1,0));
            //this.World.Scene.Add(new Triangle(1, 0));
            //this.World.Scene.Add(new Triangle(-2, 0));
            //this.World.Scene.Add(new Sprite(0, 0, "Dark-Wood-Texture.jpg"));
            //this.World.Scene.Add(new Sprite(2.0f, 2.0f, "Grass.jpg"));
            //this.World.Scene.Add(new Sprite(0.0f, 0.0f, "runesurprised.png", 0.8f));
            this.World.Scene.Add(new Circle(0f, 0f, "planet1.png", 1));


        }

        public void Run()
        {
            Window.Run();
        }
    }
}
