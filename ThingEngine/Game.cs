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
        internal GameInput Input { get; private set; }

        public virtual void Setup()
        {
            Window = new GameWindow();
            Window.Location = new System.Drawing.Point(100, 100);
            World = new GameWorld();
            Input = new GameInput(Window);
            Renderer = new GameRenderer(Window, World);            
        }
    }
}
