using RPGExplorer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPGExplorer.Modules
{
    class ContainerComponent : Component, IContainer
    {
        public event EventHandler<InsertingEventArgs> Inserting;
        public event EventHandler<InsertedEventArgs> Inserted;
        public event EventHandler<RemovingEventArgs> Removing;
        public event EventHandler<RemovedEventArgs> Removed;

        public string MsgInsertFailAlreadyContained { get; set; } = "The {0} is already in the {1}!";
        public string MsgRemoveFailNotFound { get; set; } = "There's no {0} in the {1}.";
        
        public IEnumerable<Entity> Contents => Entity.Children.Where(e => e.IsVisible);

        public bool Insert(Entity actor, Entity entity)
        {
            // Get perceptor
            var perceptor = actor.GetComponent<IPerceptor>();

            // Make sure the entity isn't already in this container
            if (Entity.Children.Contains(entity))
            {
                // Perceive that the entity is already in this container
                perceptor?.Perceive(new Stimulus(string.Format(MsgInsertFailAlreadyContained, entity.Name.ToLowerInvariant(), Entity.Name.ToLowerInvariant())));
                return false;
            }

            // Invoke the Inserting event
            var insertingArgs = new InsertingEventArgs(actor, entity);
            Inserting?.Invoke(this, insertingArgs);

            // If the event was cancelled, return false
            if (insertingArgs.Cancel) { return false; }

            // If the entity is in another container, try removing it from there first;
            // if the remotion fails, the insertion must also fail
            if (entity.Parent.GetComponent<Interfaces.IContainer>(out var otherContainer) && !otherContainer.Remove(actor, entity)) { return false; }

            // Insert the entity in this container
            entity.Parent = Entity;

            // The entity was successfully inserted, invoke the Inserted event
            Inserted?.Invoke(this, new InsertedEventArgs(actor, entity));
            return true;
        }

        public bool Remove(Entity actor, Entity entity)
        {
            // Get perceptor
            var perceptor = actor.GetComponent<IPerceptor>();

            // Make sure the entity is a child
            if (!Entity.Children.Contains(entity))
            {
                // Perceive that the child was not found
                perceptor?.Perceive(new Stimulus(string.Format(MsgRemoveFailNotFound, entity.Name.ToLowerInvariant(), container.Name.ToLowerInvariant())));
                return false;
            }

            // Invoke the Removing event
            var removingArgs = new RemovingEventArgs(actor, entity);
            Removing?.Invoke(this, removingArgs);

            // If the event was cancelled, return false
            if (removingArgs.Cancel) { return false; }

            // Remove the entity from this container
            entity.Parent = null;

            // The entity was successfully removed, invoke the Removed event
            Removed?.Invoke(this, new RemovedEventArgs(actor, entity));
            return true;
        }
    }
}