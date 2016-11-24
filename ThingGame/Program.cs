using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace ThingGame
{
    class Program
    {
        private static GameWindow _window;

        static void Main(string[] args)
        {
            _window = new GameWindow();

            _window.Resize += ResizeWindow;
            _window.RenderFrame += RenderFrame;
            _window.Run();
        }

        private static void RenderFrame(object sender, FrameEventArgs e)
        {
            GL.ClearColor(Color4.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(-1.0f, -1.0f, 4.0f);

            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(1.0f, -1.0f, 4.0f);

            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(0.0f, 1.0f, 4.0f);

            GL.End();

            _window.SwapBuffers();

        }

        private static void ResizeWindow(object sender, EventArgs e)
        {
            //GL.Viewport(0, 0, _window.Width, _window.Height);


            GL.Viewport(_window.ClientRectangle.X, _window.ClientRectangle.Y, _window.ClientRectangle.Width, _window.ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, _window.Width / (float)_window.Height, 1.0f, 64.0f);

            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadMatrix(ref projection);
        }
    }
}
