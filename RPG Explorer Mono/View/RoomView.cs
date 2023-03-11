using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPGExplorer.Interfaces;
using System;
using System.Collections.Generic;

namespace RPGExplorer.View
{
    class RoomView : Interfaces.IDrawable
    {
        // Inherited by IDrawable
        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            // Draw background
            if (Background != null)
                batch.Draw(Background, new Rectangle(Constants.GraphicsAreaViewportX, Constants.GraphicsAreaViewportY, Background.Width, Background.Height), Color.White);

            // Draw room elements
            foreach (var drawable in Drawables)
                drawable.Draw(gameTime, batch);
        }

        // RoomView
        public Texture2D Background { private get; set; }

        private List<Interfaces.IDrawable> Drawables { get; }
        
        public RoomView(Texture2D background, params Interfaces.IDrawable[] drawables)
        {
            Background = background;
            Drawables = new List<Interfaces.IDrawable>(drawables);
        }

        public void AddDrawable(Interfaces.IDrawable drawable)
        {
            // If the drawable is destroyable, register
            if (drawable is IDestroyable destroyable)
                destroyable.Destroying += OnDestroyingView;

            // Add drawable
            Drawables.Add(drawable);
        }

        public void RemoveDrawable(Interfaces.IDrawable drawable)
        {
            // Remove drawable
            Drawables.Remove(drawable);

            // If the drawable is a disposable view, unregister
            if (drawable is IDestroyable destroyable)
                destroyable.Destroying -= OnDestroyingView;
        }

        private void OnDestroyingView(object sender, EventArgs args) => RemoveDrawable(sender as Interfaces.IDrawable);
    }
}