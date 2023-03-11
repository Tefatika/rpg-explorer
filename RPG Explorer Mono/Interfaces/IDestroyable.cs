using System;

namespace RPGExplorer.Interfaces
{
    interface IDestroyable
    {
        event EventHandler Destroying;

        void Destroy();
    }
}