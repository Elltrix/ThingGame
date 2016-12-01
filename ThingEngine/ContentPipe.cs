using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace ThingEngine
{
    class ContentPipe
    {
        public static int LoadTextures(string path)
        {
            if (!File.Exists("Content/" + path))
            {
                throw new FileNotFoundException("File not found at 'Content/" + path + "'");
            }

            // Generate new texture ID and open the space for it
            int id = GL.GenTexture();

            // All GL calls targeted to follow texture
            GL.BindTexture(TextureTarget.Texture2D, id);

            //Loads in all the data to the bitmap
            Bitmap bmp = new Bitmap("Content/" + path);
            //Hold the data in memory (so we can work on it)
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), 
            ImageLockMode.ReadOnly, 
            System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            // Pass data over to openGL
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
            OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bmp.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            return id;


        }
    }
}
