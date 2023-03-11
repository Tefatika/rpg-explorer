using RPGExplorer.Actions;
using RPGExplorer.Interfaces;
using RPGExplorer.Modules;
using System;
using System.Collections.Generic;

namespace RPGExplorer.Entities
{
    /*
    class ContainerEntity : PhysicalEntity, IContainer
    {
        // Inherited by IContainer
        public event EventHandler<InsertingEventArgs> Inserting;
        public event EventHandler<InsertedEventArgs> Inserted;
        public event EventHandler<RemovingEventArgs> Removing;
        public event EventHandler<RemovedEventArgs> Removed;
        public IReadOnlyCollection<Entity> Contents => ContainerModule.Contents;
        public bool Insert(Entity entity, IPerceptor perceptor = null) => ContainerModule.Insert(entity, perceptor);
        public bool Remove(Entity entity, IPerceptor perceptor = null) => ContainerModule.Remove(entity, perceptor);

        // Inherited by BaseEntity
        public override string GetActionResultMessage(ActionType actionType)
        {
            // Get base message
            var message = GetBaseActionResultMessage(actionType);

            // If actionType is examine, add contents
            if (actionType == ActionType.Examine)
                message += "\n" + ContainerUtils.GetContentsAsString(this);

            // Return
            return message;
        }

        // ContainerEntity
        private IContainer ContainerModule { get; }

        public ContainerEntity(string name, params string[] aliases) : base(name, aliases)
        {
            ContainerModule = new ContainerModule(this);
            ContainerModule.Inserting += OnInserting;
            ContainerModule.Inserted += OnInserted;
            ContainerModule.Removing += OnRemoving;
            ContainerModule.Removed += OnRemoved;
        }

        private void OnInserting(object source, InsertingEventArgs args) => Inserting?.Invoke(this, args);
        private void OnInserted(object source, InsertedEventArgs args) => Inserted?.Invoke(this, args);
        private void OnRemoving(object source, RemovingEventArgs args) => Removing?.Invoke(this, args);
        private void OnRemoved(object source, RemovedEventArgs args) => Removed?.Invoke(this, args);
    }
    */
}