using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace ThingEngine
{
    public class Sprite : GameObject
    {

        int texture;

        public Sprite(float x, float y, string texturePath) : base(x, y)
        {
            texture = ContentPipe.LoadTextures(texturePath);
        }

        public override void Draw()
        {

            // Modify current matrix
            GL.Translate(X, Y, 4);
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.Begin(PrimitiveType.Quads);

            //GL.Color3(1.0f, 0.0f, 0.0f);
            GL.TexCoord2(0,1);
            GL.Vertex3(-1.0f, -1.0f, 0.0f);

            //GL.Color3(0.0f, 1.0f, 0.0f);
            GL.TexCoord2(1,1);
            GL.Vertex3(1.0f, -1.0f, 0.0f);

            //GL.Color3(0.0f, 0.0f, 1.0f);
            GL.TexCoord2(1,0);
            GL.Vertex3(1.0f, 1.0f, 0.0f);

            //GL.Color3(0.0f, 0.0f, 1.0f);
            GL.TexCoord2(0,0);
            GL.Vertex3(-1.0f, 1.0f, 0.0f);

            GL.End();
        }

    }
}
