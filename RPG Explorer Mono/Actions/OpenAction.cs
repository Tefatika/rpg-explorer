using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Actions
{
    class OpenAction : IAction
    {
        // Inherited by IAction
        public void Execute() => Openable.Open(Perceptor);

        // OpenAction
        private IPerceptor Perceptor { get; }
        private IOpenable Openable { get; }

        public OpenAction(IOpenable openable, IPerceptor perceptor = null)
        {
            // Null check
            if (openable is null) throw new ArgumentNullException("[OpenAction] - openable was null.");

            // Initialization
            Perceptor = perceptor;
            Openable = openable;
        }
    }
}