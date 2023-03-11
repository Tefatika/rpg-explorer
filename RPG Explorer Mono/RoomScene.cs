using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPGExplorer.Entities;
using RPGExplorer.Interfaces;
using RPGExplorer.UI;
using RPGExplorer.View.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPGExplorer
{
    class RoomScene : IScene
    {
        // Inherited by IDrawable
        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (currentRoom != null)
            {
                // Draw room graphics
                currentRoom.GetComponent<Interfaces.IDrawable>()?.Draw(gameTime, batch);

                // Draw UI
                batch.Draw(UITexture, new Rectangle(0, 0, UITexture.Width, UITexture.Height), Color.White);

                // Draw room's name
                RoomName.Draw(gameTime, batch);

                // Draw room's description
                foreach (var text in RoomDescription)
                    text.Draw(gameTime, batch);

                // Draw player perception
                foreach (var text in PlayerPerception)
                    text.Draw(gameTime, batch);
            }

            // Draw player text input
            PlayerTextInput.Draw(gameTime, batch);

            // Draw game version
            batch.DrawString(Font, Constants.Version, new Vector2(4, Constants.LogicalResY - 8), Color.White);
        }

        // Inherited by IUpdatable
        public void Update(GameTime gameTime)
        {
            if (CurrentRoom != null)
            {
                // For each room entity
                foreach (var entity in CurrentRoom.Children)
                {
                    // If entity is updatable
                    if (entity is IUpdatable updatable)
                    {
                        // Update entity
                        updatable.Update(gameTime);
                    }
                }
            }
        }

        // RoomScene
        private Entity currentRoom;
        public Entity CurrentRoom
        {
            get => currentRoom;
            set
            {
                // Set the new room
                currentRoom = value;

                // Set the room's description
                var roomDescriptionLines = currentRoom.GetComponent<IRoomDescriptor>().RoomDescription.Split('\n', '\r');
                RoomDescription = new DrawableText[roomDescriptionLines.Length];
                float y = Constants.TextAreaViewportY;
                for (int i = 0; i < roomDescriptionLines.Length; ++i)
                {
                    // Create the DrawableText
                    var dt = new DrawableText(Font)
                    {
                        Position = new Vector2(Constants.TextAreaViewportX, y),
                        MaxWidth = Constants.TextAreaViewportW,
                        Text = roomDescriptionLines[i],
                        Color = Color.Wheat
                    };

                    // Add the DrawableText to the room description array
                    RoomDescription[i] = dt;

                    // Add the height to y
                    y += dt.Size.Y + Font.LineSpacing / 2;
                }

                // Set player perception starting y
                PlayerPerceptionStartingY = y + Font.LineSpacing;

                // Clear player perception
                PlayerPerception.Clear();
            }
        }

        public event EventHandler WorldTicking;
        public event EventHandler WorldTicked;

        public Entity Player { get; }
        
        // UI
        private Texture2D UITexture { get; }
        private SpriteFont Font { get; }
        private PlayerTextInput PlayerTextInput { get; }
        private DrawableText RoomName { get; set; }
        private DrawableText[] RoomDescription { get; set; }
        private float PlayerPerceptionStartingY { get; set; }
        private float PlayerPerceptionCurrentY { get; set; }
        private List<DrawableText> PlayerPerception { get; set; } = new List<DrawableText>();

        public RoomScene(GameWindow gameWindow, GraphicsDevice graphicsDevice, SpriteFont textFont, Texture2D uiTexture, List<List<string>> dictionary)
        {
            // Null check
            if (gameWindow is null) { throw new ArgumentNullException(nameof(gameWindow)); }
            if (graphicsDevice is null) { throw new ArgumentNullException(nameof(graphicsDevice)); }
            if (dictionary is null) { throw new ArgumentNullException(nameof(graphicsDevice)); }

            // Set variables
            UITexture = uiTexture ?? throw new ArgumentNullException(nameof(uiTexture));
            Font = textFont ?? throw new ArgumentNullException(nameof(textFont));
            PlayerTextInput = new PlayerTextInput(gameWindow, graphicsDevice, textFont);
            RoomName = new DrawableText(Font)
            {
                Alignment = DrawableText.Align.MIDDLE,
                Position = new Vector2(Constants.RoomNameX, Constants.RoomNameY),
                Color = Color.Wheat
            };

            // Create player
            //Player = new PlayerEntity(PlayerTextInput, dictionary);

            // Attach event handlers
            //Player.Acting += OnPlayerActing;
            //Player.Acted += OnPlayerActed;
            //Player.ChangingRoom += OnPlayerChangingRoom;
            //Player.Perceived += OnPlayerPerception;
        }

        /*
        private void OnPlayerActing(object source, ActorActingEventArgs args)
        {
            PlayerPerception.Clear();
            PlayerPerceptionCurrentY = PlayerPerceptionStartingY;
        }

        private void OnPlayerActed(object source, ActorActedEventArgs args)
        {
            void DispatchTick(TreeNode node)
            {
                // Dispatch to children
                foreach (var child in node.Children)
                    DispatchTick(child);

                // If the current node handles ticks, tick it
                if (node is ITickable tickable)
                    tickable.Tick(args.TicksCount);
            }

            // Invoke ticking event
            WorldTicking?.Invoke(this, EventArgs.Empty);

            // Dispatch tick update to every room
            foreach (var room in Rooms)
                DispatchTick(room.Item1);

            // Invoke ticked event
            WorldTicked?.Invoke(this, EventArgs.Empty);
        }

        private void OnPlayerChangingRoom(object source, PlayerRoomChangeEventArgs args) => CurrentRoom = args.NewRoom;

        private void OnPlayerPerception(object source, PlayerPerceptionEventArgs args)
        {
            var lines = args.Stimulus.Message.Split('\n', '\r');
            foreach (var line in lines)
            {
                // Create DrawableText
                var dt = new DrawableText(Font)
                {
                    Position = new Vector2(Constants.TextAreaViewportX, PlayerPerceptionCurrentY),
                    MaxWidth = Constants.TextAreaViewportW,
                    Text = line
                };
                PlayerPerception.Add(dt);

                // Add the height to y
                PlayerPerceptionCurrentY += dt.Size.Y + Font.LineSpacing / 2;
            }
        }
        */
    }
}