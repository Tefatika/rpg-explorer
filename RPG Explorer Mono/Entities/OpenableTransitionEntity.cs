using RPGExplorer.Actions;
using RPGExplorer.Interfaces;
using RPGExplorer.Modules;
using System;

namespace RPGExplorer.Entities
{
    /*
    class OpenableTransitionEntity : TransitionEntity, IOpenable
    {
        // Inherited by Entity
        public override string GetActionResultMessage(ActionType actionType)
        {
            // Get base message
            string msg = base.GetActionResultMessage(actionType);

            // If examining
            if (actionType == ActionType.Examine)
                return msg + '\n' + (IsOpen ? OpenedExamineMsg : ClosedExamineMsg);

            // else return
            return msg;
        }

        // Inherited by TransitionEntity
        public override bool CanGo(Entity entity, IPerceptor perceptor = null) => IsOpen ? base.CanGo(entity, perceptor) : false;

        // Inherited by IOpenable
        public event EventHandler<ClosingEventArgs> Closing;
        public event EventHandler<ClosedEventArgs> Closed;
        public event EventHandler<OpeningEventArgs> Opening;
        public event EventHandler<OpenedEventArgs> Opened;

        public bool IsOpen => OpenableModule.IsOpen;
        public bool Close(IPerceptor perceptor) => OpenableModule.Close(perceptor);
        public bool Open(IPerceptor perceptor) => OpenableModule.Open(perceptor);

        // OpenableTransitionEntity
        private IOpenable OpenableModule { get; }
        public string ClosedExamineMsg { private get; set; } = "It is currently closed.";
        public string OpenedExamineMsg { private get; set; } = "It is currently open.";

        public OpenableTransitionEntity(string name, params string[] aliases) : base(name, aliases)
        {
            OpenableModule = new OpenableModule(this);
            OpenableModule.Closing += OnClosing;
            OpenableModule.Closed += OnClosed;
            OpenableModule.Opening += OnOpening;
            OpenableModule.Opened += OnOpened;
        }

        private void OnClosing(object source, ClosingEventArgs e) => Closing?.Invoke(this, e);
        private void OnClosed(object source, ClosedEventArgs e) => Closed?.Invoke(this, e);
        private void OnOpening(object source, OpeningEventArgs e) => Opening?.Invoke(this, e);
        private void OnOpened(object source, OpenedEventArgs e) => Opened?.Invoke(this, e);
    }
    */
}