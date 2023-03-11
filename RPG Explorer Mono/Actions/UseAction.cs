using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Actions
{
    class UseAction : IAction
    {
        // Inherited by IAction
        public void Execute() => Usable.Use();

        // UseAction
        private IUsable Usable { get; }

        public UseAction(IUsable usable)
        {
            // Null check
            if (usable is null) throw new ArgumentNullException("[UseAction] - usable was null.");

            // Initialization
            Usable = usable;
        }
    }
}