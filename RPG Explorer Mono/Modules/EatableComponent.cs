using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Modules
{
    class EatableComponent : Component, IEatable
    {
        public event EventHandler Eating;
        public event EventHandler Eaten;

        private string Message { get; } = "I've eaten the {0}.";

        public void Eat()
        {
            // Invoke the Eating event
            Eating?.Invoke(this, EventArgs.Empty);

            // Dispatch stimulus
            //Entity.Parent.DispatchStimulus(new Stimulus(string.Format(Message, Parent.Name.ToLowerInvariant())));

            // Invoke the Eaten event
            Eaten?.Invoke(this, EventArgs.Empty);
        }
    }
}