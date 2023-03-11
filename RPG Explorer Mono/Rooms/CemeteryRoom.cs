using Microsoft.Xna.Framework.Graphics;
using RPGExplorer.Actions;
using RPGExplorer.Entities;
using RPGExplorer.View;

namespace RPGExplorer.Rooms
{
    /*
    class CemeteryRoom : Room
    {
        // Constants
        private const string RoomName = "Cemetery";
        private const string RoomDescription = "Graves, graves everywhere.\nIn the distance, I can barely make out the shape of the old church, now inhabited by the caretaker only.";
        private const string RoomFirstTimeDescription = "I stepped outside the crypt and into the cemetery.\n"
            + "It's raining. I FUCK MYSELF in my heavy coat.\n"
            + "Off in the distance, I can barely make out the shape of the old church, now inhabited by the caretaker.";

        // CemeteryRoom
        private bool FirstTime { get; set; } = true;
        public override string Description
        {
            get
            {
                if (FirstTime)
                {
                    FirstTime = false;
                    return RoomFirstTimeDescription;
                }
                else
                    return RoomDescription;
            }
        }

        public RoomView View { get; }

        public CemeteryRoom(Texture2D background) : base(RoomName)
        {
            // Add stone
            var stone = new PhysicalEntity("Stone", "Rock", "Pebble", "Cobble", "Cobblestone")
            {
                CanBeTaken = true
            };
            stone.SetActionResultMessage(ActionType.Examine, "Just an ordinary rock.");
            stone.SetActionResultMessage(ActionType.Eat, "I'm not hungry, thank you.");
            AddChild(stone);

            // Add sky
            AddChild(Common.CreateSky());

            // Create ground
            AddChild(Common.CreateCemeteryGround());

            // Create puddle
            AddChild(Common.CreateCemeteryPuddle());

            // Add crypt
            var crypt = new TransitionEntity("Crypt", "Tomb")
            {
                DestinationId = RoomId.Crypt
            };
            crypt.SetActionResultMessage(ActionType.Examine, "My family crypt is almost indistinguishable from the others in this darkness, but I know which one is by heart.");
            AddChild(crypt);

            // Add church
            var nearChurch = new TransitionEntity("Church", "Chapel", "Temple", "Building", "Construction", "House", "Home", "Caretaker")
            {
                DestinationId = RoomId.NearChurch
            };
            nearChurch.SetActionResultMessage(ActionType.Examine, "I don't know why the caretaker still lives in that church. Everybody stopped attending, yet he's adamant in staying there, waiting for somebody to come.\nI guess that's what you call faith.");
            AddChild(nearChurch);

            // Create view
            View = new RoomView(background);
        }
    }
    */
}