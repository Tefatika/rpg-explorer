using System;
using System.ComponentModel;

namespace RPGExplorer.Interfaces
{
    public interface IOpenable
    {
        event EventHandler<ClosingEventArgs> Closing;
        event EventHandler<ClosedEventArgs> Closed;
        event EventHandler<OpeningEventArgs> Opening;
        event EventHandler<OpenedEventArgs> Opened;

        bool IsOpen { get; }

        bool Close(Entity actor);
        bool Open(Entity actor);
    }

    public class ClosingEventArgs : CancelEventArgs
    {
        public Entity Actor;

        public ClosingEventArgs(Entity actor)
        {
            Actor = actor ?? throw new ArgumentNullException(nameof(actor));
        }
    }

    public class ClosedEventArgs : EventArgs
    {
        public Entity Actor;

        public ClosedEventArgs(Entity actor)
        {
            Actor = actor ?? throw new ArgumentNullException(nameof(actor));
        }
    }

    public class OpeningEventArgs : CancelEventArgs
    {
        public Entity Actor;

        public OpeningEventArgs(Entity actor)
        {
            Actor = actor ?? throw new ArgumentNullException(nameof(actor));
        }
    }

    public class OpenedEventArgs : EventArgs
    {
        public Entity Actor;

        public OpenedEventArgs(Entity actor)
        {
            Actor = actor ?? throw new ArgumentNullException(nameof(actor));
        }
    }
}