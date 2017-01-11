using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameAndroidPerformance
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private SpriteFont _font;

        // Performance
        private FPSCounter _fpsCounter = new FPSCounter();
        private Stopwatch _stopWatch = new Stopwatch();
        private TimeSpan _updateTime;
        private TimeSpan _drawTime;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.Portrait;

            // Unlock FPS
            //IsFixedTimeStep = false;
            //graphics.SynchronizeWithVerticalRetrace = false;
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

            _font = Content.Load<SpriteFont>("font");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            _fpsCounter.Update(gameTime);

            _stopWatch.Reset();
            _stopWatch.Start();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);

            _updateTime = _stopWatch.Elapsed;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _fpsCounter.Draw(gameTime);

            _stopWatch.Reset();
            _stopWatch.Start();

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _drawTime = _stopWatch.Elapsed;

            base.Draw(gameTime);

            spriteBatch.Begin();

            spriteBatch.DrawString(_font, $"FPS: {_fpsCounter.FramesPerSecond}", Vector2.Zero, Color.White);
            spriteBatch.DrawString(_font, $"Update time: {_updateTime.TotalMilliseconds} ms", new Vector2(0, 20f), Color.White);
            spriteBatch.DrawString(_font, $"Draw time: { _drawTime.TotalMilliseconds } ms", new Vector2(0, 40f), Color.White);

            spriteBatch.End();
        }
    }
}
