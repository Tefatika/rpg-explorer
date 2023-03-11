using RPGExplorer.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RPGExplorer
{
    /*
    abstract class TreeNode: IDestroyable
    {
        // Inherited by IDestroyable
        public event EventHandler Destroying;
        public void Destroy()
        {
            // Invoke destroying event
            Destroying?.Invoke(this, EventArgs.Empty);

            // Destroy every child
            foreach (var child in ChildrenList)
                child.Destroy();
        }

        // TreeNode
        public TreeNode Parent { get; private set; }
        public abstract Room CurrentRoom { get; }

        public IReadOnlyCollection<Entity> Children => ChildrenList.AsReadOnly();

        private List<Entity> ChildrenList { get; } = new List<Entity>();

        public Entity[] GetChildren(string name)
        {
            // Match children
            List<Entity> matches = new List<Entity>(ChildrenList.Where(x => x.CheckName(name)));

            // Recursion on every child
            foreach (var child in ChildrenList)
                matches.AddRange(child.GetChildren(name));

            // Return
            return matches.ToArray();
        }
        
        public Entity[] GetVisibleChildren(string name)
        {
            // Get visible children
            var visibleChildren = ChildrenList.Where(x => x.IsVisible);

            // Match children
            List<Entity> matches = new List<Entity>(visibleChildren.Where(x => x.CheckName(name)));

            // Recursion on every child
            foreach (var child in visibleChildren)
                matches.AddRange(child.GetVisibleChildren(name));

            // Return
            return matches.ToArray();
        }

        public bool AddChild(Entity entity)
        {
            // If already a child, return false
            if (ChildrenList.Contains(entity))
                return false;

            // Remove child from its current parent
            entity.Parent?.RemoveChild(entity);

            // Add to children
            ChildrenList.Add(entity);
            entity.Parent = this;

            // Attach to the Destroying event
            entity.Destroying += OnChildDestroying;

            // Return true
            return true;
        }

        public bool RemoveChild(Entity entity)
        {
            // If not successfully removed, return false
            if (!ChildrenList.Remove(entity))
                return false;

            // Reset parent
            entity.Parent = null;

            // Detach from the Destroying event
            entity.Destroying -= OnChildDestroying;
                
            // Return true
            return true;
        }

        private void OnChildDestroying(object source, EventArgs args) => RemoveChild((Entity)source);
    }
    */
}