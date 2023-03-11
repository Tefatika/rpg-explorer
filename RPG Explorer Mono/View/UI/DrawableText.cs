using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Text;

namespace RPGExplorer.View.UI
{
    class DrawableText : Interfaces.IDrawable
    {
        public enum Align : int { LEFT = 0, MIDDLE = 1, RIGHT = 2 }

        // Inherited by IDrawable
        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (SplitText != null)
                batch.DrawString(Font, SplitText, DrawPosition, Color);
        }

        // DrawableText
        private string text;
        public string Text
        {
            get => text;
            set { if (text != value) { text = value; UpdateText(); } }
        }

        private SpriteFont font;
        public SpriteFont Font
        {
            get => font;
            set
            {
                if (value == null) throw new ArgumentNullException("[DrawableText] - font was null.");

                if (font != value)
                {
                    font = value;
                    UpdateText();
                }
            }
        }

        private Vector2 position;
        public Vector2 Position
        {
            get => position;
            set { position = value; UpdatePosition(); }
        }

        private Align alignment = Align.LEFT;
        public Align Alignment
        {
            get => alignment;
            set { alignment = value; UpdatePosition(); }
        }

        public Color Color { get; set; } = Color.White;

        private Vector2 size;
        public Vector2 Size
        {
            get => size;
            private set { size = value; UpdatePosition(); }
        }

        private float maxWidth = 0f;
        public float MaxWidth
        {
            get => maxWidth;
            set { if (maxWidth != value) { maxWidth = value; UpdateText(); } }
        }

        private string SplitText { get; set; }
        private Vector2 DrawPosition { get; set; }

        public DrawableText(SpriteFont font) => Font = font;

        private void UpdateText()
        {
            if (string.IsNullOrWhiteSpace(Text))
                SplitText = null;
            else if (maxWidth <= 0f)
                SplitText = Text;
            else
            {
                // String builder
                StringBuilder sb = new StringBuilder();

                // The current x position
                float x = 0;

                // Split the description in lines
                var lines = Text.Split(new char[] { '\n', '\r' });

                // For each line
                for (int i = 0; i < lines.Length; ++i)
                {
                    // Split the line in words
                    var words = lines[i].Split(' ');

                    // For each word
                    for (int j = 0; j < words.Length; ++j)
                    {
                        // Build word, adding a space if not the last
                        var word = (j == words.Length - 1) ? words[j] : words[j] + ' ';

                        // Measure word
                        float dim = Font.MeasureString(word).X;
                        x += dim;

                        // If word would exceed the max width
                        if (x > MaxWidth)
                        {
                            // Add carriage return
                            sb.Append('\n');

                            // Update x
                            x = dim;
                        }

                        // Append word
                        sb.Append(word);
                    }

                    // If this isn't the last line
                    if (i < lines.Length - 1)
                    {
                        // Add carriage return
                        sb.Append('\n');

                        // Reset x position
                        x = 0f;
                    }
                }

                // Set text lines
                SplitText = sb.ToString();
            }

            // Update text size
            Size = SplitText == null ? Vector2.Zero : Font.MeasureString(SplitText);
        }

        private void UpdatePosition() => DrawPosition = new Vector2(Position.X - (int)Alignment * Size.X / 2, Position.Y);
    }
}