using RPGExplorer.Interfaces;
using System;
using System.Linq;

namespace RPGExplorer
{
    /*
    abstract class Room : TreeNode, INamed
    {
        // Inherited by INamed
        public string Name { get; }
        public bool CheckName(string name) => string.Equals(Name, name, StringComparison.InvariantCultureIgnoreCase);

        // Inherited by TreeNode
        public override Room CurrentRoom => this;

        // Room
        public abstract string Description { get; }

        public Room(string name)
        {
            // Null check
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("[Room] - name was empty.");

            // Initialization
            Name = name;
        }

        public void DispatchStimulus(Stimulus stimulus)
        {
            // Dispatch stimulus to all children
            foreach (IPerceptor perceptor in Children.OfType<IPerceptor>())
                perceptor.Perceive(stimulus);
        }
    }
    */
}