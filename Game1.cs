using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace multiplayertriangle
{
    
    public struct KeyboardInput
    {
        public Keys key;
        public GameTime gameTime;
    }
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState oldState;
        Queue<KeyboardInput> keyboardbuffer;
        Ship redShip;
        Ship greenShip;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            keyboardbuffer = new Queue<KeyboardInput>();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            oldState = Keyboard.GetState();
            
            redShip = new Ship(this,graphics,Vector2.Zero);
            redShip.LoadContent(Content, "RedTriangle");

            Vector2 position = new Vector2(200, 200);
            greenShip = new Ship(this, graphics,position);
            
            greenShip.LoadContent(Content, "GreenTriangle");

            base.Initialize();
        }

        /// <summary>   
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
           


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit

            KeyboardState newState = Keyboard.GetState();
            KeyboardInput item; 
           
            //keyboardbuffer.Enqueue(

            if (newState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (newState.IsKeyDown(Keys.Left))
            {
                item.key = Keys.Left;
                item.gameTime = gameTime;
                keyboardbuffer.Enqueue(item);
            }

            if (newState.IsKeyDown(Keys.Right))
            {

                item.key = Keys.Right;
                item.gameTime = gameTime;
                keyboardbuffer.Enqueue(item);
            }

            if (newState.IsKeyDown(Keys.Up))
            {
                item.key = Keys.Up;
                item.gameTime = gameTime;
                keyboardbuffer.Enqueue(item);
            }

            if (newState.IsKeyDown(Keys.Down))
            {
                item.key = Keys.Down;
                item.gameTime = gameTime;
                keyboardbuffer.Enqueue(item);
            }

            //left
            if (newState.IsKeyDown(Keys.L))
            {

                item.key = Keys.L;
                item.gameTime = gameTime;
                keyboardbuffer.Enqueue(item);
            }

            //right
            if (newState.IsKeyDown(Keys.R))
            {
                item.key = Keys.R;
                item.gameTime = gameTime;
                keyboardbuffer.Enqueue(item);
            }

            //Up
            if (newState.IsKeyDown(Keys.U))
            {
                item.key = Keys.U;
                item.gameTime = gameTime;
                keyboardbuffer.Enqueue(item);
            }

            //Down
            if (newState.IsKeyDown(Keys.D))
            {
                item.key = Keys.D;
                item.gameTime = gameTime;
                keyboardbuffer.Enqueue(item);
            }


            if (keyboardbuffer.Count > 0)
            {
                KeyboardInput currentInput = keyboardbuffer.Dequeue();
                Keys key = currentInput.key;
                switch (key)
                {
                    case Keys.Down:
                        redShip.MoveDown();
                        break;
                    case Keys.Left:
                        redShip.MoveLeft();
                        break;
                    case Keys.Right:
                        redShip.MoveRight();
                        break;
                    case Keys.Up:
                        redShip.MoveUp();
                        break;

                    case Keys.L:
                        greenShip.MoveLeft();
                        break;
                    case Keys.R:
                        greenShip.MoveRight();
                        break;
                    case Keys.U:
                        greenShip.MoveUp();
                        break;
                    case Keys.D:
                        greenShip.MoveDown();
                        break;

                    default:
                        break;
                }
                
            }
            // Update saved state.
            oldState = newState;

            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            redShip.Draw(gameTime);
            greenShip.Draw(gameTime);

            // Draw the sprite.
             


            base.Draw(gameTime);
        }
    }
}
