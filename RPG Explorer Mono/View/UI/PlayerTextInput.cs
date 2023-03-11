using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPGExplorer.Interfaces;
using System;
using System.Windows.Forms;

namespace RPGExplorer.UI
{
    class PlayerTextInput : IPlayerTextInput, Interfaces.IDrawable
    {
        // Inherited by IPlayerTextInput
        public event EventHandler<TextInputEnteredEventArgs> InputEntered;

        // Inherited by IDrawable
        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            // Draw the > character
            batch.DrawString(Font, ">", new Vector2(Constants.PlayerInputViewportX - 10, Constants.PlayerInputViewportY), Color.White);

            // Calculate cursor position
            var textSize = Font.MeasureString(Text.Substring(0, CursorPosition));
            var cursorRect = new Rectangle((int)(Constants.PlayerInputViewportX + textSize.X), Constants.PlayerInputViewportY, CursorTexture.Width, CursorTexture.Height);

            // If there's a selection
            if (CursorPosition != CursorSelectionPosition)
            {
                // Calculate selection position
                var selectedTextSize = Font.MeasureString(Text.Substring(Math.Min(CursorPosition, CursorSelectionPosition), Math.Abs(CursorPosition - CursorSelectionPosition)));
                var selectionRect = new Rectangle(
                    (int)(Constants.PlayerInputViewportX + textSize.X - (CursorPosition > CursorSelectionPosition ? selectedTextSize.X : 0)),
                    Constants.PlayerInputViewportY,
                    (int)selectedTextSize.X,
                    CursorTexture.Height);

                // Draw selection
                batch.Draw(CursorTexture, selectionRect, Color.DarkBlue);
            }

            // Draw text
            batch.DrawString(Font, Text, new Vector2(Constants.PlayerInputViewportX, Constants.PlayerInputViewportY), Color.White);

            // Draw cursor
            batch.Draw(CursorTexture, cursorRect, Color.White);
        }

        // PlayerTextInput
        private string Text { get; set; } = string.Empty;
        private int CursorPosition { get; set; } = 0;
        private int CursorSelectionPosition { get; set; } = 0;

        private Form Form { get; }

        private SpriteFont Font { get; }
        private Texture2D CursorTexture { get; }

        public PlayerTextInput(GameWindow gameWindow, GraphicsDevice graphicsDevice, SpriteFont inputTextFont)
        {
            Form = Control.FromHandle(gameWindow.Handle) as Form;
            Font = inputTextFont;

            // Create a texture for the cursor
            CursorTexture = new Texture2D(graphicsDevice, 1, Font.LineSpacing);

            Color[] data = new Color[Font.LineSpacing];
            for (int j = 0; j < Font.LineSpacing; ++j)
                data[j] = Color.White;

            CursorTexture.SetData(data);

            // Register to the window's TextInput event
            Form.PreviewKeyDown += OnPreviewKeyDown;
            Form.KeyDown += OnKeyDown;
            Form.KeyPress += OnKeyPress;
        }

        ~PlayerTextInput()
        {
            // Dispose of cursor texture
            CursorTexture.Dispose();

            // Unregister from the TextInput event
            Form.PreviewKeyDown -= OnPreviewKeyDown;
            Form.KeyDown -= OnKeyDown;
            Form.KeyPress -= OnKeyPress;
        }

        private void OnPreviewKeyDown(object sender, PreviewKeyDownEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                    args.IsInputKey = true;
                    break;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.Back:
                    if (Math.Max(CursorPosition, CursorSelectionPosition) > 0)
                    {
                        if (CursorSelectionPosition == CursorPosition)
                            --CursorSelectionPosition;

                        Text = Text.Remove(Math.Min(CursorPosition, CursorSelectionPosition), Math.Abs(CursorPosition - CursorSelectionPosition));
                        CursorPosition = CursorSelectionPosition = Math.Min(CursorPosition, CursorSelectionPosition);
                    }
                    break;

                case Keys.Delete:
                    if (Text.Length > 0 && Math.Min(CursorPosition, CursorSelectionPosition) < Text.Length)
                    {
                        if (CursorSelectionPosition == CursorPosition)
                            ++CursorSelectionPosition;

                        Text = Text.Remove(Math.Min(CursorPosition, CursorSelectionPosition), Math.Abs(CursorPosition - CursorSelectionPosition));
                        CursorPosition = CursorSelectionPosition = Math.Min(CursorPosition, CursorSelectionPosition);
                    }
                    break;

                case Keys.Enter:
                    if (!string.IsNullOrEmpty(Text))
                    {
                        // Invoke event
                        InputEntered?.Invoke(this, new TextInputEnteredEventArgs(Text));

                        // Reset input
                        CursorPosition = CursorSelectionPosition = 0;
                        Text = string.Empty;
                    }
                    break;

                case Keys.Home:
                case Keys.End:
                    CursorPosition = args.KeyCode == Keys.Home ? 0 : Text.Length;
                    if (!args.Shift)
                        CursorSelectionPosition = CursorPosition;
                    break;

                case Keys.Left:
                    if (args.Shift)
                    {
                        CursorPosition = Math.Max(0, CursorPosition - 1);
                    }
                    else
                    {
                        if (CursorPosition != CursorSelectionPosition)
                            CursorPosition = CursorSelectionPosition = Math.Min(CursorPosition, CursorSelectionPosition);
                        else
                            CursorPosition = CursorSelectionPosition = Math.Max(0, CursorPosition - 1);
                    }
                    break;

                case Keys.Right:
                    if (args.Shift)
                    {
                        CursorPosition = Math.Min(Text.Length, CursorPosition + 1);
                    }
                    else
                    {
                        if (CursorPosition != CursorSelectionPosition)
                            CursorPosition = CursorSelectionPosition = Math.Max(CursorPosition, CursorSelectionPosition);
                        else
                            CursorPosition = CursorSelectionPosition = Math.Min(Text.Length, CursorPosition + 1);
                    }
                    break;
            }
        }

        private void OnKeyPress(object sender, KeyPressEventArgs args)
        {
            if (Font.Characters.Contains(args.KeyChar))
            {
                if (CursorPosition != CursorSelectionPosition)
                {
                    Text = Text.Remove(Math.Min(CursorPosition, CursorSelectionPosition), Math.Abs(CursorPosition - CursorSelectionPosition));
                    CursorPosition = CursorSelectionPosition = Math.Min(CursorPosition, CursorSelectionPosition);
                }

                Text = Text.Insert(CursorPosition, args.KeyChar.ToString());
                ++CursorPosition;
                ++CursorSelectionPosition;
            }
        }
    }
}