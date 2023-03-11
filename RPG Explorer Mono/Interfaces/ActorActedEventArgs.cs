using System;

namespace RPGExplorer.Interfaces
{
    class ActorActedEventArgs : EventArgs
    {
        public int TicksCount { get; }

        public ActorActedEventArgs(int ticksCount) => TicksCount = ticksCount;
    }
}