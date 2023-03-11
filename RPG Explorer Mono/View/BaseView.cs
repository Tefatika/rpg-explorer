using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.View
{
    class BaseView : IDestroyable
    {
        // Inherited by IDisposableView
        public event EventHandler Destroying;

        // BaseView
        public virtual void Destroy() => Destroying?.Invoke(this, EventArgs.Empty);
        
    }
}