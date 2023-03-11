using RPGExplorer.Interfaces;
using RPGExplorer.Modules;
using RPGExplorer.Parser;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RPGExplorer.Entities
{
    /*
    class PlayerPerceptionEventArgs : EventArgs
    {
        public Stimulus Stimulus { get; }
        public PlayerPerceptionEventArgs(Stimulus stimulus) => Stimulus = stimulus;
    }

    class PlayerRoomChangeEventArgs : EventArgs
    {
        public Room NewRoom { get; }
        public Room LastRoom { get; }

        public PlayerRoomChangeEventArgs(Room newRoom, Room lastRoom)
        {
            NewRoom = newRoom;
            LastRoom = lastRoom;
        }
    }

    class PlayerEntity : PhysicalEntity, IActor, IPerceptor, IContainer, IHitter
    {
        // Constants
        private const string HittingSelf = "Yeah, no. I won't hit myself. Nice try.";

        // Player events
        public event EventHandler<PlayerRoomChangeEventArgs> ChangingRoom;
        public event EventHandler<PlayerPerceptionEventArgs> Perceived;

        // Inherited by IPerceptor
        public void Perceive(Stimulus stimulus) => Perceived?.Invoke(this, new PlayerPerceptionEventArgs(stimulus));

        // Inherited by ITaker
        public void Take(Entity entity) => TakerModule.Take(entity);
        public void Put(Entity entity, Entity target) => TakerModule.Put(entity, target);
        public void Drop(Entity entity) => TakerModule.Drop(entity);

        // Inherited by IActor
        public event EventHandler<ActorActingEventArgs> Acting;
        public event EventHandler<ActorActedEventArgs> Acted;

        public void Go(ITransition transition)
        {
            if (transition.Destination != Parent && transition.CanGo(this, this))
            {
                var lastRoom = Parent as Room;
                ChangingRoom?.Invoke(this, new PlayerRoomChangeEventArgs(transition.Destination, lastRoom));
                transition.Destination.AddChild(this);
            }
            else if (transition.Destination is null)
                Perceive(new Stimulus("Apparently, I just tried to walk into a place that doesn't exist!\n(Yes, this is most likely a bug.)"));
        }

        // Inherited by IContainer
        public event EventHandler<InsertingEventArgs> Inserting;
        public event EventHandler<InsertedEventArgs> Inserted;
        public event EventHandler<RemovingEventArgs> Removing;
        public event EventHandler<RemovedEventArgs> Removed;
        public IReadOnlyCollection<Entity> Contents => ContainerModule.Contents;
        public bool Insert(Entity entity, IPerceptor perceptor = null) => ContainerModule.Insert(entity);
        public bool Remove(Entity entity, IPerceptor perceptor = null) => ContainerModule.Remove(entity);
        
        // Inherited by IHitter
        public void Hit(PhysicalEntity target, PhysicalEntity means = null)
        {
            // If trying to hit himself
            if (target == this)
                Perceive(new Stimulus(HittingSelf));
            else
            {
                // Call ReceiveHit on the target
                target.ReceiveHit(means ?? this);
            }
        }

        // Modules
        private ContainerModule ContainerModule { get; }
        private TakerModule TakerModule { get; }

        // Player
        private IPlayerTextInput TextInput { get; }
        private InputParser Parser { get; }

        public PlayerEntity(IPlayerTextInput textInput, List<List<string>> dictionary) : base("Player", "Me", "Myself")
        {
            // Initialize variables
            TextInput = textInput ?? throw new ArgumentNullException("[PlayerEntity] - textInput was null.");

            // Initialize parser
            Parser = new InputParser(dictionary);

            // Initialize modules
            TakerModule = new TakerModule(this, this);
            ContainerModule = new ContainerModule(this);
            ContainerModule.Inserting += OnInserting;
            ContainerModule.Inserted += OnInserted;
            ContainerModule.Removing += OnRemoving;
            ContainerModule.Removed += OnRemoved;

            // Subscribe to the player input event
            TextInput.InputEntered += OnTextInputEntered;
        }

        private void OnTextInputEntered(object source, TextInputEnteredEventArgs args)
        {
            // Get action based on input
            var action = Parser.GetAction(this, args.Input);

            // Assert: null check
            Debug.Assert(action != null, "[Player] - Parser returned null action.");

            // Invoke Acting event
            Acting?.Invoke(this, new ActorActingEventArgs());

            // Execute action
            action.Execute();

            // Invoke Acted event
            Acted.Invoke(this, new ActorActedEventArgs(ticksCount: 1));
        }

        private void OnInserting(object source, InsertingEventArgs args) => Inserting?.Invoke(this, args);
        private void OnInserted(object source, InsertedEventArgs args) => Inserted?.Invoke(this, args);
        private void OnRemoving(object source, RemovingEventArgs args) => Removing?.Invoke(this, args);
        private void OnRemoved(object source, RemovedEventArgs args) => Removed?.Invoke(this, args);
    }
    */
}