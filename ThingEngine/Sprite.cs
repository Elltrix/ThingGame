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

        private readonly int? _texture;
        private readonly float _scale;

        public Sprite(float x, float y, string texturePath, float scale = 1) : base(x, y)
        {
            _texture = ContentPipe.LoadTextures(texturePath);
            _scale = scale;
        }

        public override void Draw()
        {

            // Modify current matrix
            GL.Translate(X, Y, 4);
            GL.Scale(_scale, _scale, _scale);

            if (_texture.HasValue)
                GL.BindTexture(TextureTarget.Texture2D, _texture.Value);

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
