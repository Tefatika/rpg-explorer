using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace RPGExplorer.View
{
    class EntityView : BaseView, Interfaces.IDrawable
    {
        // Inherited by BaseView
        public override void Destroy()
        {
            // Remove events
            RoomScene.WorldTicked -= OnWorldTicked;
            Entity.Destroying -= OnEntityDestroying;

            // Call base destroy
            base.Destroy();
        }

        // Inherited by IDrawable
        public void Draw(GameTime gameTime, SpriteBatch batch) => batch.Draw(Texture, DstRect, SrcRect, Color.White);

        // OpenableContainerView
        private RoomScene RoomScene { get; }
        private Entity Entity { get; }

        private Texture2D Texture { get; }
        private int SpriteCountX { get; }
        private int SpriteWidth { get; }
        private int SpriteHeight { get; }
        private Rectangle SrcRect { get; set; }
        private Rectangle DstRect { get; }
		private Func<int> IndexCalculatorFunc { get; }

        public EntityView(RoomScene roomScene, Point position, Texture2D texture, Entity entity, Func<int> calculatorFunc = null, int spriteCountX = 1, int spriteCountY = 1)
		{
            // Set variables
            RoomScene = roomScene;
            Entity = entity;
            Texture = texture;
            SpriteCountX = spriteCountX;
            IndexCalculatorFunc = calculatorFunc;
            SpriteWidth = texture.Width / SpriteCountX;
            SpriteHeight = texture.Height / spriteCountY;

            // Initialize texture
            int index = IndexCalculatorFunc?.Invoke() ?? 0;
            SrcRect = new Rectangle(SpriteWidth * (index % SpriteCountX), SpriteHeight * (index / SpriteCountX), SpriteWidth, SpriteHeight);
            DstRect = new Rectangle(position, new Point(SpriteWidth, SpriteHeight));

            // Register to the events
            roomScene.WorldTicked += OnWorldTicked;
            entity.Destroying += OnEntityDestroying;
        }

        private void UpdateIndex()
        {
            if (IndexCalculatorFunc != null)
            {
                int index = IndexCalculatorFunc();

                var srcRect = SrcRect;
                srcRect.X = SpriteWidth * (index % SpriteCountX);
                srcRect.Y = SpriteHeight * (index / SpriteCountX);

                SrcRect = srcRect;
            }
        }

        private void OnEntityDestroying(object sender, EventArgs args) => Destroy();
        private void OnWorldTicked(object sender, EventArgs args) => UpdateIndex();
    }
}