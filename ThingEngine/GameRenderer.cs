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
    public class GameRenderer
    {
        private GameWindow window;
        private GameWorld world;

        public GameRenderer(GameWindow window, GameWorld world)
        {
            this.window = window;
            this.world = world;

            window.Resize += ResizeWindow;
            window.RenderFrame += RenderFrame;
        }

        private void RenderFrame(object sender, FrameEventArgs e)
        {
            GL.ClearColor(Color4.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            foreach (var item in world.Scene)
            {
                item.Draw();

            }

            window.SwapBuffers();

        }

        private void ResizeWindow(object sender, EventArgs e)
        {
            //GL.Viewport(0, 0, _window.Width, _window.Height);


            GL.Viewport(window.ClientRectangle.X, window.ClientRectangle.Y, window.ClientRectangle.Width, window.ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, window.Width / (float)window.Height, 1.0f, 64.0f);

            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadMatrix(ref projection);
        }
    }
}
