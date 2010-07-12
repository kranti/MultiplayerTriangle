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

       
    
    class Ship
    {
        SpriteBatch spriteBatch;
        Texture2D myTexture;
        // Set the coordinates to draw the sprite at.
        Vector2 spritePosition = Vector2.Zero;
        // Store some information about the sprite's motion.
        Vector2 spriteSpeed = new Vector2(50.0f, 50.0f);
        Game game;

        int MaxX;
        int MinX;
        int MaxY;
        int MinY;
        GraphicsDeviceManager graphics;


        public Ship(Game game, GraphicsDeviceManager graphics, Vector2 spritePosition)
        {

            this.graphics = graphics;
            this.game = game;
            this.spritePosition = spritePosition;


            
        }

        public void LoadContent(ContentManager Content,string assetName)
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);

            myTexture = Content.Load<Texture2D>(assetName);

        }

        public void MoveLeft()
        {
            spritePosition.X--;
        }

        public void MoveRight()
        {
            spritePosition.X++;
        }

        public void MoveUp()
        {
            spritePosition.Y--;
        }

        public void MoveDown()
        {
            spritePosition.Y++;
        }


        public void Update(GameTime gameTime)
        {
            // Move the sprite by speed, scaled by elapsed time.
            spritePosition +=
                spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            MaxX = graphics.GraphicsDevice.Viewport.Width - myTexture.Width;
            MinX = 0;
            MaxY = graphics.GraphicsDevice.Viewport.Height - myTexture.Height;
            MinY = 0;

            // Check for bounce.
            if (spritePosition.X > MaxX)
            {
                spriteSpeed.X *= -1;
                spritePosition.X = MaxX;
            }

            else if (spritePosition.X < MinX)
            {
                spriteSpeed.X *= -1;
                spritePosition.X = MinX;
            }

            if (spritePosition.Y > MaxY)
            {
                spriteSpeed.Y *= -1;
                spritePosition.Y = MaxY;
            }

            else if (spritePosition.Y < MinY)
            {
                spriteSpeed.Y *= -1;
                spritePosition.Y = MinY;
            }

        }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            spriteBatch.Draw(myTexture, spritePosition, Color.White);
            spriteBatch.End();
        }
    }
}
