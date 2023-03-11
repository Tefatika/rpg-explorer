using RPGExplorer.Actions;
using RPGExplorer.Interfaces;
using RPGExplorer.Modules;
using System;

namespace RPGExplorer.Entities
{
    /*
    class OpenableContainerEntity : ContainerEntity, IOpenable
    {
        // Inherited by IOpenable
        public event EventHandler<ClosingEventArgs> Closing;
        public event EventHandler<ClosedEventArgs> Closed;
        public event EventHandler<OpeningEventArgs> Opening;
        public event EventHandler<OpenedEventArgs> Opened;

        public bool IsOpen => OpenableModule.IsOpen;
        public bool Close(IPerceptor perceptor = null) => OpenableModule.Close(perceptor);
        public bool Open(IPerceptor perceptor = null) => OpenableModule.Open(perceptor);

        // Inherited by Entity
        public override string GetActionResultMessage(ActionType actionType)
        {
            // If actionType is examine and the container is closed
            if (actionType == ActionType.Examine && !IsOpen)
                return GetBaseActionResultMessage(actionType) + "\n" + string.Format(ClosedExamineMsg, Name.ToLower());
            else
                return base.GetActionResultMessage(actionType); // Delegate to base class
        }

        // OpenableContainerEntity
        private IOpenable OpenableModule { get; }
        public string ClosedExamineMsg { private get; set; } = "The {0} is currently closed.";
        public string ClosedFailMsg { private get; set; } = "You can't do that, the {0} is closed!";

        public OpenableContainerEntity(string name, params string[] aliases) : base(name, aliases)
        {
            OpenableModule = new OpenableModule(this);
            OpenableModule.Closing += OnClosing;
            OpenableModule.Closed += OnClosed;
            OpenableModule.Opening += OnOpening;
            OpenableModule.Opened += OnOpened;
        }

        private void OnInserting(object source, InsertingEventArgs eventArgs)
        {
            // If the container is not open
            if (!IsOpen)
            {
                // Abort insertion
                eventArgs.Cancel = true;

                // Send stimulus
                eventArgs.Perceptor?.Perceive(new Stimulus(string.Format(ClosedFailMsg, Name.ToLowerInvariant())));
            }
        }

        private void OnRemoving(object source, RemovingEventArgs eventArgs)
        {
            // If the container is not open
            if (!IsOpen)
            {
                // Abort remotion
                eventArgs.Cancel = true;

                // Send stimulus
                eventArgs.Perceptor?.Perceive(new Stimulus(string.Format(ClosedFailMsg, Name.ToLowerInvariant())));
            }
        }

        private void OnClosing(object source, ClosingEventArgs e) => Closing?.Invoke(this, e);
        private void OnClosed(object source, ClosedEventArgs e) => Closed?.Invoke(this, e);
        private void OnOpening(object source, OpeningEventArgs e) => Opening?.Invoke(this, e);
        private void OnOpened(object source, OpenedEventArgs e) => Opened?.Invoke(this, e);
    }
    */
}