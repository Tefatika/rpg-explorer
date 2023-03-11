using System;
using System.ComponentModel;

namespace RPGExplorer
{
    class BeingHitEventArgs : CancelEventArgs
    {
        PhysicalEntity Hitter { get; }

        public BeingHitEventArgs(PhysicalEntity hitter) => Hitter = hitter ?? throw new ArgumentNullException("[BeingHitEventArgs] - hitter was null.");
    }

    class BeenHitEventArgs : EventArgs
    {
        PhysicalEntity Hitter { get; }

        public BeenHitEventArgs(PhysicalEntity hitter) => Hitter = hitter ?? throw new ArgumentNullException("[BeenHitEventArgs] - hitter was null.");
    }

    class PhysicalEntity : Entity
    {
        public event EventHandler<BeingHitEventArgs> BeingHit;
        public event EventHandler<BeenHitEventArgs> BeenHit;

        public PhysicalEntity(string name, params string[] aliases) : base(name, aliases) {}

        public bool ReceiveHit(PhysicalEntity hitter)
        {
            // Invoke the BeingHit event
            var e = new BeingHitEventArgs(hitter);
            BeingHit?.Invoke(this, e);

            // If cancelled, return false
            if (e.Cancel)
                return false;

            // Invoke the BeenHit event
            BeenHit?.Invoke(this, new BeenHitEventArgs(hitter));

            // Return
            return true;
        }
    }
}