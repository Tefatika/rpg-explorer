using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPGExplorer.Interfaces
{
    interface IDrawable
    {
        void Draw(GameTime gameTime, SpriteBatch batch);
    }
}