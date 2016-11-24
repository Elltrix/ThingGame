using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingEngine;

using OpenTK.Graphics.OpenGL;

namespace TriangleWars
{
    public class Triangle : GameObject
    {
        public Triangle(float x, float y)
            : base(x, y)
        {
        }


        public override void Draw()
        {

            // Modify current matrix
            GL.Translate(X, Y, 4);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(-1.0f, -1.0f, 0.0f);

            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(1.0f, -1.0f, 0.0f);

            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(0.0f, 1.0f, 0.0f);

            GL.End();
        }
    }
}
