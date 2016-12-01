using System;
using OpenTK;
using OpenTK.Input;
using System.Collections.Generic;

namespace ThingEngine
{
    internal class GameInput
    {
        private List<char> keysPressed;
        private GameWindow window;

        public GameInput(GameWindow window)
        {
            keysPressed = new List<char>();

            this.window = window;            
            window.KeyPress += KeyPress_EventHandler;
        }

        private void KeyPress_EventHandler(object sender, KeyPressEventArgs e)
        {

            keysPressed.Add(e.KeyChar);
           
        }
    }
}