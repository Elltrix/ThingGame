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

        // Create game window(the world), and resize it to fit physical window
        public GameRenderer(GameWindow window, GameWorld world)
        {
            this.window = window;
            this.world = world;

            window.Resize += ResizeWindow;
            window.RenderFrame += RenderFrame;
        }

        private Vector3 camera = Vector3.Zero;

        private void RenderFrame(object sender, FrameEventArgs e)
        {
            // Detect key press to move camera
            var keyboardState = window.Keyboard.GetState();
            const float camera_speed = 0.1f;

            if (keyboardState.IsKeyDown(OpenTK.Input.Key.Left))
            {                
                camera.X += camera_speed;
            }
            if (keyboardState.IsKeyDown(OpenTK.Input.Key.Right))
            {
                camera.X -= camera_speed;
            }

            if (keyboardState.IsKeyDown(OpenTK.Input.Key.Up))
            {
                camera.Y += camera_speed;
            }
            if (keyboardState.IsKeyDown(OpenTK.Input.Key.Down))
            {
                camera.Y -= camera_speed;
            }



            GL.ClearColor(Color4.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Setup view position for camera, the Z is set specificaly so it does not rotate around an object.
            Matrix4 modelview = Matrix4.LookAt(camera, camera + Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            foreach (var item in world.Scene)
            {
                // Save current matrix (save state)
                GL.PushMatrix();

                item.Draw();

                GL.PopMatrix();
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
