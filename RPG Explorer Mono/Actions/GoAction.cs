using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Actions
{
    class GoAction : IAction
    {
        private readonly IActor actor;
        private readonly ITransition transition;

        public GoAction(IActor actor, ITransition transition)
        {
            this.actor = actor ?? throw new ArgumentNullException(nameof(actor));
            this.transition = transition ?? throw new ArgumentNullException(nameof(transition));
        }

        public void Execute()
        {
            actor.Go(transition);
        }
    }
}