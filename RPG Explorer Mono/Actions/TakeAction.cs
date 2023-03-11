using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Actions
{
    class TakeAction : IAction
    {
        // Inherited by IAction
        public void Execute() => Taker.Take(Entity);

        // TakeAction
        private ITaker Taker { get; }
        private Entity Entity { get; }

        public TakeAction(ITaker taker, Entity entity)
        {
            Taker = taker ?? throw new ArgumentNullException("[TakeAction] - taker was null.");
            Entity = entity ?? throw new ArgumentNullException("[TakeAction] - entity was null.");
        }
    }
}