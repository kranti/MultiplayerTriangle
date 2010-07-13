using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace multiplayerships
{

    public struct KeyboardInput
    {
        public Keys key;
        public int ID;
       
    }
    
    class KeyboardInputHandler
    {
        public Queue<KeyboardInput> keyboardbuffer;
        static int id = 0;

        public KeyboardInputHandler()
        {

            keyboardbuffer = new Queue<KeyboardInput>();
        }
        

        public void WriteBuffer(object state)
        {
            lock (this)
            {
                KeyboardState newState = Keyboard.GetState();
                KeyboardInput item;

                if (newState.IsKeyDown(Keys.Left))
                {
                    item.key = Keys.Left;
                    item.ID = KeyboardInputHandler.id++;
                    keyboardbuffer.Enqueue(item);
                }

                if (newState.IsKeyDown(Keys.Right))
                {

                    item.key = Keys.Right;
                    item.ID = KeyboardInputHandler.id++;
                    keyboardbuffer.Enqueue(item);
                }

                if (newState.IsKeyDown(Keys.Up))
                {
                    item.key = Keys.Up;
                    item.ID = KeyboardInputHandler.id++;
                    keyboardbuffer.Enqueue(item);
                }

                if (newState.IsKeyDown(Keys.Down))
                {
                    item.key = Keys.Down;
                    item.ID = KeyboardInputHandler.id++;
                    keyboardbuffer.Enqueue(item);
                }

                //left
                if (newState.IsKeyDown(Keys.L))
                {

                    item.key = Keys.L;
                    item.ID = KeyboardInputHandler.id++;
                    keyboardbuffer.Enqueue(item);
                }

                //right
                if (newState.IsKeyDown(Keys.R))
                {
                    item.key = Keys.R;
                    item.ID = KeyboardInputHandler.id++;
                    keyboardbuffer.Enqueue(item);
                }

                //Up
                if (newState.IsKeyDown(Keys.U))
                {
                    item.key = Keys.U;
                    item.ID = KeyboardInputHandler.id++;
                    keyboardbuffer.Enqueue(item);
                }

                //Down
                if (newState.IsKeyDown(Keys.D))
                {
                    item.key = Keys.D;
                    item.ID = KeyboardInputHandler.id++;
                    keyboardbuffer.Enqueue(item);
                } 
            }

        }

       public Keys ReadBuffer()
        {
            lock (this)
            {
                Keys key = Keys.None;
                if (keyboardbuffer.Count > 0)
                {
                    KeyboardInput currentInput = keyboardbuffer.Dequeue();
                    key = currentInput.key;
                }
                return key; 
            }
        }
    }
}
