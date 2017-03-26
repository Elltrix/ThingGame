using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;


namespace ThingEngine
{
    public class Circle : GameObject
    {
        private const float DEG2RAD = 0.01745329252f;
        private readonly int? _texture;
        private readonly float _scale;

        public Circle(float x, float y, string texturePath, float scale = 1) : base(x, y)
        {
            _texture = ContentPipe.LoadTextures(texturePath);
            _scale = scale;
        }

        public override void Draw()
        {

            // Modify current matrix
            GL.Translate(X, Y, 4);
            //GL.Scale(_scale, _scale, _scale);

            if (_texture.HasValue)
                GL.BindTexture(TextureTarget.Texture2D, _texture.Value);

            GL.Begin(PrimitiveType.TriangleFan);

            for (int i = 0; i < 360; i++)
            {
                float degInRad = i * DEG2RAD;
                double xcos = Math.Cos(degInRad);
                double ycos = Math.Sin(degInRad);
                GL.Vertex3(xcos * _scale, ycos * _scale, 0.0f);
                GL.TexCoord2(xcos * 0.5 + 0.5, ycos * 0.5 + 0.5);
            }

            GL.End();
        }
    }
}
