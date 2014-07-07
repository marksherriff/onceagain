using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.GamerServices;
using Tao.Sdl;

namespace OnceAgain
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class OnceAgainMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
		Sprite sprite;
        public OnceAgainMain()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here

			sprite = new Sprite(50, 50, 50, 50);
			base.Initialize();

			Joystick.Init ();
			Console.WriteLine("Number of joysticks: " + Sdl.SDL_NumJoysticks());
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
			sprite.LoadContent(this.Content);
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
			//set our keyboardstate tracker update can change the gamestate on every cycle
			KeyboardState keyboard = Keyboard.GetState();
			GamePadState p1_gamepad = GamePad.GetState (PlayerIndex.One);

			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here
			//Up, down, left, right affect the coordinates of the sprite


			if (keyboard.IsKeyDown(Keys.S)  || (p1_gamepad.ThumbSticks.Left.Y < -0.5f)) // 
			{
				sprite.spriteY += 5;
			}
			if (keyboard.IsKeyDown(Keys.W) || (p1_gamepad.ThumbSticks.Left.Y > 0.5f)) //  
			{
				sprite.spriteY -= 5;
			}
			if(keyboard.IsKeyDown(Keys.D) || p1_gamepad.ThumbSticks.Left.X > 0.5f)
			{
				sprite.spriteX += 5;
			}
			if (keyboard.IsKeyDown(Keys.A) || p1_gamepad.ThumbSticks.Left.X < -0.5f)
			{
				sprite.spriteX -= 5;
			}


			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			spriteBatch.Begin();
			sprite.Draw(spriteBatch);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
