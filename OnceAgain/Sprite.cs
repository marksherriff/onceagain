using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace OnceAgain
{
    class Sprite
    {
        public int spriteX, spriteY;
        private int spriteWidth, spriteHeight;
        private Texture2D image;



        public Sprite(int x, int y, int width, int height)
        {
            this.spriteX = x;
            this.spriteY = y;
            this.spriteWidth = width;
            this.spriteHeight = height;
        }

        public int getX(){
            return spriteX;
        }
        public int getY()
        {
            return spriteY;
        }
        public void setX(int x)
        {
            spriteX = x;
        }
        public void setY(int y)
        {
            spriteY = y;
        }

        public void LoadContent(ContentManager content)
        {
            image = content.Load<Texture2D>("prep2.png");
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle(spriteX, spriteY, spriteWidth, spriteHeight), Color.White);
        }

		public void Update(KeyboardState keyboard, GamePadState p1_gamepad)
		{
			Move (keyboard, p1_gamepad);
		}

		public void Move(KeyboardState keyboard, GamePadState p1_gamepad)
		{
			if (keyboard.IsKeyDown(Keys.S)  || (p1_gamepad.ThumbSticks.Left.Y < -0.5f)) // 
			{
				spriteY += 5;
			}
			if (keyboard.IsKeyDown(Keys.W) || (p1_gamepad.ThumbSticks.Left.Y > 0.5f)) //  
			{
				spriteY -= 5;
			}
			if(keyboard.IsKeyDown(Keys.D) || p1_gamepad.ThumbSticks.Left.X > 0.5f)
			{
				spriteX += 5;
			}
			if (keyboard.IsKeyDown(Keys.A) || p1_gamepad.ThumbSticks.Left.X < -0.5f)
			{
				spriteX -= 5;
			}
		}

    }
}
