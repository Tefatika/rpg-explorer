using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Modules
{
    class OpenableComponent : Component, IOpenable
    {
        public event EventHandler<ClosingEventArgs> Closing;
        public event EventHandler<ClosedEventArgs> Closed;
        public event EventHandler<OpeningEventArgs> Opening;
        public event EventHandler<OpenedEventArgs> Opened;

        public string ClosedMsg { get; set; } = "I closed the {0}.";
        public string OpenedMsg { get; set; } = "I opened the {0}.";
        public string AlreadyClosedMsg { get; set; } = "The {0} is already closed.";
        public string AlreadyOpenedMsg { get; set; } = "The {0} is already open.";

        public bool IsOpen { get; private set; }

        public bool Close(Entity actor)
        {
            // Get perceptor
            var perceptor = actor.GetComponent<IPerceptor>();

            // Fail if already closed
            if (!IsOpen)
            {
                perceptor?.Perceive(new Stimulus(string.Format(AlreadyClosedMsg, Entity.Name.ToLowerInvariant())));
                return false;
            }

            // Invoke the Closing event
            var e = new ClosingEventArgs(actor);
            Closing?.Invoke(this, e);

            // If cancelling, return false
            if (e.Cancel) { return false; }

            // Reset IsOpen flag
            IsOpen = false;

            // Dispatch stimulus
            perceptor?.Perceive(new Stimulus(string.Format(ClosedMsg, Entity.Name.ToLowerInvariant())));

            // Invoke the Closed event
            Closed?.Invoke(this, new ClosedEventArgs(actor));

            // Return
            return true;
        }

        public bool Open(Entity actor)
        {
            // Get perceptor
            var perceptor = actor.GetComponent<IPerceptor>();

            // Fail if already opened
            if (IsOpen)
            {
                perceptor?.Perceive(new Stimulus(string.Format(AlreadyOpenedMsg, Entity.Name.ToLowerInvariant())));
                return false;
            }

            // Invoke the Opening event
            var e = new OpeningEventArgs(actor);
            Opening?.Invoke(this, e);

            // If cancelling, return false
            if (e.Cancel) { return false; }

            // Set IsOpen flag
            IsOpen = true;

            // Dispatch stimulus
            perceptor?.Perceive(new Stimulus(string.Format(OpenedMsg, Entity.Name.ToLowerInvariant())));

            // Invoke the Opened event
            Opened?.Invoke(this, new OpenedEventArgs(actor));

            // Return
            return true;
        }
    }
}