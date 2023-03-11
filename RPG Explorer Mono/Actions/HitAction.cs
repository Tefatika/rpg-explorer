using RPGExplorer.Interfaces;
using System;

namespace RPGExplorer.Actions
{
    class HitAction : IAction
    {
        private readonly IHitter hitter;
        private readonly Entity target;
        private readonly Entity means;

        public HitAction(IHitter hitter, Entity target, Entity means = null)
        {
            this.hitter = hitter ?? throw new ArgumentNullException(nameof(hitter));
            this.target = target ?? throw new ArgumentNullException(nameof(target));
            this.means = means;
        }

        public void Execute()
        {
            hitter.Hit(target, means);
        }
    }
}