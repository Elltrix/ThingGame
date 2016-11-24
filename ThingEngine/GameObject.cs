using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;

namespace ThingEngine
{
    public class GameObject
    {

        public GameObject(float x, float y)
        {
            X = x;
            Y = Y;
        }


        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;

        public virtual void Draw()
        {
            
        }


        public void Update()
        {

        }
    }
}
