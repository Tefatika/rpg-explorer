using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RPGExplorer.Interfaces
{
    interface IContainer
    {
        event EventHandler<InsertingEventArgs> Inserting;
        event EventHandler<InsertedEventArgs> Inserted;
        event EventHandler<RemovingEventArgs> Removing;
        event EventHandler<RemovedEventArgs> Removed;

        IEnumerable<Entity> Contents { get; }

        bool Insert(Entity actor, Entity entity);
        bool Remove(Entity actor, Entity entity);
    }

    public class InsertingEventArgs : CancelEventArgs
    {
        public InsertingEventArgs(Entity actor, Entity entity)
        {
            Actor = actor ?? throw new ArgumentNullException(nameof(actor));
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }

        public Entity Actor { get; }
        public Entity Entity { get; }
    }

    public class InsertedEventArgs : EventArgs
    {
        public InsertedEventArgs(Entity actor, Entity entity)
        {
            Actor = actor ?? throw new ArgumentNullException(nameof(actor));
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }

        public Entity Actor { get; }
        public Entity Entity { get; }
    }

    public class RemovingEventArgs : CancelEventArgs
    {
        public RemovingEventArgs(Entity actor, Entity entity)
        {
            Actor = actor ?? throw new ArgumentNullException(nameof(actor));
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }

        public Entity Actor { get; }
        public Entity Entity { get; }
    }

    public class RemovedEventArgs : EventArgs
    {
        public RemovedEventArgs(Entity actor, Entity entity)
        {
            Actor = actor ?? throw new ArgumentNullException(nameof(actor));
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }

        public Entity Actor { get; }
        public Entity Entity { get; }
    }
}