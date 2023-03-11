using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Actions
{
    class EatAction : IAction
    {
        // Inherited by IAction
        public void Execute() => Eatable.Eat();

        // EatAction
        private IEatable Eatable { get; }

        public EatAction(IEatable eatable)
        {
            // Null check
            if (eatable is null) throw new ArgumentNullException("[EatAction] - eatable was null.");

            // Initialization
            Eatable = eatable;
        }
    }
}