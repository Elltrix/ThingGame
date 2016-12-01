using System;
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
            this.World.Scene.Add(new Sprite(0, 0));


        }

        public void Run()
        {
            Window.Run();
        }
    }
}
