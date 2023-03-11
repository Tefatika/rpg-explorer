using System;

namespace RPGExplorer.Interfaces
{
    interface IPlayerTextInput
    {
        event EventHandler<TextInputEnteredEventArgs> InputEntered;
    }
}