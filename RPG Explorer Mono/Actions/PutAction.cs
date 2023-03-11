using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Actions
{
    class PutAction : IAction
    {
        // Inherited by IAction
        public void Execute() => Taker.Put(Entity, Target);

        // PutAction
        private ITaker Taker { get; }
        private Entity Entity { get; }
        private Entity Target { get; }

        public PutAction(ITaker taker, Entity entity, Entity target)
        {
            // Null check
            if (taker is null) throw new ArgumentNullException("[PutAction] - taker was null.");
            if (entity is null) throw new ArgumentNullException("[PutAction] - entity was null.");
            if (target is null) throw new ArgumentNullException("[PutAction] - target was null.");

            // Initialization
            Taker = taker;
            Entity = entity;
            Target = target;
        }
    }
}