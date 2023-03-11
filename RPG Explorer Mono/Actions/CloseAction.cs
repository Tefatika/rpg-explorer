using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Actions
{
    class CloseAction : IAction
    {
        // Inherited by IAction
        public void Execute() => Openable.Close(Perceptor);

        // CloseAction
        private IPerceptor Perceptor { get; }
        private IOpenable Openable { get; }

        public CloseAction(IOpenable openable, IPerceptor perceptor = null)
        {
            // Null check
            if (openable is null) throw new ArgumentNullException("[CloseAction] - openable was null.");

            // Initialization
            Perceptor = perceptor;
            Openable = openable;
        }
    }
}