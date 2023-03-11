using RPGExplorer.Interfaces;
using System.Linq;

namespace RPGExplorer.Modules
{
    public class TakerComponent : Component, ITaker
    {
        public string TakenMsg { get; set; } = "I've taken the {0}.";
        public string PutMsg { get; set; } = "I put the {0} into the {1}.";
        public string DropMsg { get; set; } = "I dropped the {0}.";
        public string SameContainerMsg { get; set; } = "The {0} is already in my inventory!";
        public string TargetIsNotAContainerMsg { get; set; } = "You can't put a {0} into a {1}!";
        public string TargetNotPossessedMsg { get; set; } = "The {0} is not in my inventory.";

        public void Take(Entity entity)
        {
            // Perception to be shown
            string perception = null;

            // Check if trying to take an object from your own inventory
            if (Entity == entity.Parent)
            {
                perception = SameContainerMsg;
            }
            else
            {
                // If operation is valid
                if (entity.CanBeTaken)
                {
                    // Try adding the entity to this container
                    var container = Entity.GetComponent<IContainer>();
                    if (container.Insert(Entity, entity))
                    {
                        perception = string.Format(TakenMsg, entity.Name.ToLowerInvariant());
                    }
                }
            }

            // Dispatch stimulus
            if (perception != null)
            {
                Entity.GetComponent<IPerceptor>()?.Perceive(new Stimulus(string.Format(perception, entity.Name.ToLowerInvariant(), Entity.Name.ToLowerInvariant())));
            }
        }

        public void Put(Entity entity, Entity target)
        {
            // Perception to be shown
            string perception = null;

            // Make sure the entity has the item in his inventory
            var container = Entity.GetComponent<IContainer>();
            if (!container.Contents.Contains(entity))
            {
                perception = string.Format(TargetNotPossessedMsg, entity.Name.ToLowerInvariant());
            }
            else if (Entity == target) // Check if trying to put an object into your own inventory
            {
                perception = string.Format(SameContainerMsg, entity.Name.ToLowerInvariant());
            }
            else
            {
                // Check if the target is a container
                var targetContainer = target.GetComponent<IContainer>();
                if (targetContainer == null)
                {
                    perception = string.Format(TargetIsNotAContainerMsg, entity.Name.ToLowerInvariant(), target.Name.ToLowerInvariant());
                }
                else
                {
                    // Add entity to the target container
                    if (targetContainer.Insert(Entity, entity))
                    {
                        perception = string.Format(PutMsg, entity.Name.ToLowerInvariant(), target.Name.ToLowerInvariant());
                    }
                }
            }

            // Dispatch stimulus
            if (perception != null)
            {
                Entity.GetComponent<IPerceptor>()?.Perceive(new Stimulus(string.Format(perception, entity.Name.ToLowerInvariant())));
            }
        }

        public void Drop(Entity entity)
        {
            // Perception to be shown
            string perception = null;

            // Make sure the entity has the item in his inventory
            var container = Entity.GetComponent<IContainer>();
            if (!container.Contents.Contains(entity))
            {
                perception = string.Format(TargetNotPossessedMsg, entity.Name.ToLowerInvariant());
            }
            else
            {
                // Remove entity from this container
                if (container.Remove(Entity, entity))
                {
                    // Add entity to the current room
                    entity.Parent = Entity.Parent;

                    // Get message
                    perception = string.Format(DropMsg, entity.Name.ToLowerInvariant());
                }
            }

            // Dispatch stimulus
            if (perception != null)
            {
                Entity.GetComponent<IPerceptor>()?.Perceive(new Stimulus(string.Format(perception, entity.Name.ToLowerInvariant())));
            }
        }
    }
}