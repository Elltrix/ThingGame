using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace ThingEngine
{
    public class Game
    {
        protected GameWindow Window { get; private set; }
        protected GameWorld World { get; private set; }
        public GameRenderer Renderer { get; private set; }

        public virtual void Setup()
        {
            Window = new GameWindow();
            World = new GameWorld();
            Renderer = new GameRenderer(Window, World);            
        }
    }
}
