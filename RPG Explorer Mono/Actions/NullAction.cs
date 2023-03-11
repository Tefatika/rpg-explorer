using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Actions
{
    class NullAction : IAction
    {
        // Inherited by IAction
        public void Execute() => Perceptor.Perceive(Stimulus);

        // NullAction
        private IPerceptor Perceptor { get; }
        private Stimulus Stimulus { get; }

        public NullAction(IPerceptor perceptor, string msg)
        {
            // Null check
            if (perceptor is null) throw new ArgumentNullException("[NullAction] - perceptor was null.");
            if (msg is null) throw new ArgumentNullException("[NullAction] - msg was null.");

            // Initialization
            Perceptor = perceptor;
            Stimulus = new Stimulus(msg);
        }
    }
}