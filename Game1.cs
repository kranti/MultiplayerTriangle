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

namespace multiplayerships
{
    

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardInputHandler keyboardInputHandler;
        Ship redShip;
        Ship greenShip;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
           
            Content.RootDirectory = "Content";
        }

       protected override void Initialize()
        {   
            redShip = new Ship(this,graphics,Vector2.Zero);
            redShip.LoadContent(Content, "RedTriangle");

            Vector2 position = new Vector2(200, 200);
            greenShip = new Ship(this, graphics,position);
            greenShip.LoadContent(Content, "GreenTriangle");

            keyboardInputHandler = new KeyboardInputHandler();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit

            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            keyboardInputHandler.WriteBuffer();
            Keys key = keyboardInputHandler.ReadBuffer();

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


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            redShip.Draw(gameTime);
            greenShip.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
