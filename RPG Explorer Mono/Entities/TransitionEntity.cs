using RPGExplorer.Interfaces;

namespace RPGExplorer.Entities
{
    /*
    class TransitionEntity : PhysicalEntity, ITransition
    {
        // Inherited by ITransition
        public Room Destination => World.GetRoom(DestinationId);

        public virtual bool CanGo(Entity entity, IPerceptor perceptor = null) => Destination != null;

        // TransitionEntity
        public RoomId DestinationId { get; set; } = RoomId.Null;

        public TransitionEntity(string name, params string[] aliases) : base(name, aliases) { }
    }
    */
}