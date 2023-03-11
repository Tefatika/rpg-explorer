using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Actions
{
    class DropAction : IAction
    {
        // Inherited by IAction
        public void Execute() => Taker.Drop(Entity);

        // DropAction
        private ITaker Taker { get; }
        private Entity Entity { get; }

        public DropAction(ITaker taker, Entity entity)
        {
            // Null check
            if (taker is null) throw new ArgumentNullException("[DropAction] - taker was null.");
            if (entity is null) throw new ArgumentNullException("[DropAction] - entity was null.");

            // Initialization
            Taker = taker;
            Entity = entity;
        }
    }
}