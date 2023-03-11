using System;

namespace RPGExplorer.Interfaces
{
    interface IActor : IPerceptor, ITaker
    {
        event EventHandler<ActorActingEventArgs> Acting;
        event EventHandler<ActorActedEventArgs> Acted;

        void Go(ITransition transition);
    }
}