using System;

namespace RPGExplorer.Interfaces
{
    class TextInputEnteredEventArgs : EventArgs
    {
        public string Input { get; }

        public TextInputEnteredEventArgs(string input) => Input = input;
    }
}