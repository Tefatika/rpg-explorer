using System.Collections.Generic;
using System.Linq;

namespace RPGExplorer
{
    public class Entity : Object
    {
        //public bool CheckName(string name) => Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) || Aliases.Any(x => x.Equals(name, StringComparison.InvariantCultureIgnoreCase));

        // Inherited by IExaminable
        /*
        public event EventHandler<ExaminedEventArgs> Examined;

        public void Examine(IPerceptor perceptor)
        {
            // Perceive the default examine message if there's one
            var msg = GetActionResultMessage(ActionType.Examine);
            if (msg != null)
                perceptor.Perceive(new Stimulus(msg));

            // Invoke event
            Examined?.Invoke(this, new ExaminedEventArgs(perceptor));
        }
        */
        
        public string Name { get; private set; }
        public bool CanBeTaken { get; set; } = false;
        public bool IsVisible { get; set; } = true;

        public Entity Parent
        {
            get => parent;
            set
            {
                parent?.children.Remove(this);
                parent = value;
                parent?.children.Add(this);
            }
        }

        public IEnumerable<Entity> Children => children;

        private readonly List<Component> components = new List<Component>();
        private readonly List<Entity> children = new List<Entity>();
        private Entity parent;

        public T GetComponent<T>()
        {
            return components.OfType<T>().FirstOrDefault();
        }

        public bool GetComponent<T>(out T component)
        {
            component = GetComponent<T>();
            return component != null;
        }

        public IEnumerable<T> GetComponents<T>()
        {
            return components.OfType<T>();
        }
    }
}