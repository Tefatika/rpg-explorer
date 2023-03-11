using RPGExplorer.Interfaces;
using RPGExplorer.Modules;
using System;
using System.ComponentModel;

namespace RPGExplorer.Entities
{
    /*
    class EatableEntity : PhysicalEntity, IEatable
    {
        // Inherited by IEatable
        public event CancelEventHandler Eating;
        public event EventHandler Eaten;
        public bool Eat() => EatableModule.Eat();

        // EatableEntity
        private IEatable EatableModule { get; }

        public EatableEntity(string name) : base(name)
        {
            EatableModule = new EatableModule(this);
            EatableModule.Eating += OnEating;
            EatableModule.Eaten += OnEaten;
        }

        private void OnEating(object source, CancelEventArgs e) => Eating?.Invoke(this, e);
        private void OnEaten(object source, EventArgs e) => Eaten?.Invoke(this, e);
    }
    */
}