using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPGExplorer.Interfaces;
using RPGExplorer.Rooms;
using System;
using System.Collections.Generic;

namespace RPGExplorer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ExplorerGame : Game
    {
        // Variables
        private GraphicsDeviceManager graphics;
        private RenderTarget2D renderTarget;
        private SpriteBatch spriteBatch;

        private IScene CurrentScene { get; set; }
        private RoomScene RoomScene { get; set; }

        public ExplorerGame()
        {
            // Initialize the graphics device manager
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1440,
                PreferredBackBufferHeight = 810
            };

            // Set the content root directory
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
            // Set the cursor visible
            IsMouseVisible = true;

            // Initialize the render target
            renderTarget = new RenderTarget2D(graphics.GraphicsDevice, Constants.LogicalResX, Constants.LogicalResY);

            // Call base
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

            // Create scene
            CurrentScene = RoomScene = new RoomScene(Window, graphics.GraphicsDevice, Content.Load<SpriteFont>("BaseFont"), Content.Load<Texture2D>("RoomSceneUI"), Content.Load<List<List<string>>>("ActionDictionary"));

            // Create rooms
            CreateRooms(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() { }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update scene
            CurrentScene.Update(gameTime);

            // Call base
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Set the render target to our logical canvas
            GraphicsDevice.SetRenderTarget(renderTarget);

            // Clear the screen
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw the current scene
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            CurrentScene.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            // Set the backbuffer as the new render target
            GraphicsDevice.SetRenderTarget(null);

            // Draw the canvas onto the backbuffer
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            spriteBatch.Draw(renderTarget, GraphicsDevice.Viewport.Bounds, Color.White);
            spriteBatch.End();

            // Call base
            base.Draw(gameTime);
        }

        private void CreateRooms(ContentManager contentManager)
        {
            // Create rooms
            var crypt = new CryptRoom(contentManager.Load<Texture2D>("RoomCrypt"));
            var cemetery = new CemeteryRoom(contentManager.Load<Texture2D>("RoomCemetery"));
            var nearChurch = new NearChurchRoom(contentManager.Load<Texture2D>("RoomNearChurch"));

            // Add rooms to the world
            World.SetRoom(RoomId.Crypt, crypt);
            World.SetRoom(RoomId.Cemetery, cemetery);
            World.SetRoom(RoomId.NearChurch, nearChurch);

            // Add rooms to the scene
            RoomScene.AddRoom(new Tuple<Room, Interfaces.IDrawable>(crypt, crypt.View));
            RoomScene.AddRoom(new Tuple<Room, Interfaces.IDrawable>(cemetery, cemetery.View));
            RoomScene.AddRoom(new Tuple<Room, Interfaces.IDrawable>(nearChurch, nearChurch.View));

            // Set the crypt as the first active room
            RoomScene.CurrentRoom = crypt;
            crypt.AddChild(RoomScene.Player);
        }
    }
}