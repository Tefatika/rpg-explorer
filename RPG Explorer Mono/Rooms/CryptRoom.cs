using Microsoft.Xna.Framework.Graphics;
using RPGExplorer.Actions;
using RPGExplorer.Entities;
using RPGExplorer.Interfaces;
using RPGExplorer.View;

namespace RPGExplorer.Rooms
{
    /*
    class CryptRoom : Room
    {
        // Constants
        private const string RoomName = "Crypt";
        private const string RoomDescription = "It's dark and damp in here; I can barely make out the shapes of the various coffins lying around.\n"
            + "Behind me, the moonlight timidly shines through the crypt's entrance, leading to the cemetery outside.";
        private const string RoomFirstTimeDescription = "I entered the small crypt where the members of my family were once buried.\n"
            + "It's dark and damp in here; I can barely make out the shapes of the various coffins lying around. The lamp I'm carrying is my only source of light.\n"
            + "Behind me, the moonlight timidly shines through the crypt's entrance, leading to the cemetery outside.\n"
            + "I make my way to my younger sister's final resting place.";

        // CryptRoom
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

        public CryptRoom(Texture2D background) : base("Crypt")
        {
            // Create sister's coffin
            var sistersCoffin = new PhysicalEntity("Coffin", "Sis' coffin", "Sis coffin", "Sister coffin", "Tomb", "Sister tomb", "Resting place", "Sister resting place", "Casket", "Sister casket");
            sistersCoffin.SetActionResultMessage(ActionType.Examine, "This is my sister's coffin. It's been open and there are some traces of dirt on one of its sides.\nI visit her often; I can swear last time it was closed, as it should be.");
            sistersCoffin.SetActionResultMessage(ActionType.Open, "Well, the coffin is already open.");
            sistersCoffin.SetActionResultMessage(ActionType.Close, "Not before finding my sister's body.");
            sistersCoffin.SetActionResultMessage(ActionType.Use, "Tsk, over my dead body!");
            sistersCoffin.SetActionResultMessage(ActionType.Put, "I won't defile my sister's memory for your own pleasure.");
            AddChild(sistersCoffin);

            // Add second coffin
            var otherCoffin = new PhysicalEntity("Anonymous coffin", "Anonymous", "Coffin", "Anonymous coffin", "Tomb", "Anonymous tomb", "Resting place", "Anonymous resting place", "Casket", "Anonymous casket")
            {
                IsVisible = false
            };
            otherCoffin.SetActionResultMessage(ActionType.Examine, "This coffin is apparently missing an owner: there's no name to be found anywhere.\nWeird. I've never noticed this one before. I guess I should really stop visiting my sister at night.\nWhat's an empty casket doing in here anyway?");
            otherCoffin.SetActionResultMessage(ActionType.Open, "The coffin refuses to open. The bolts are missing - I shouldn't have any problem opening it but, for some reasons, I can't.");
            otherCoffin.SetActionResultMessage(ActionType.Close, "The coffin is already closed.");
            otherCoffin.SetActionResultMessage(ActionType.Take, "As stupid as an idea as it may seem, I can't lift it or even move it - this coffin seems to be glued to the floor!");
            AddChild(otherCoffin);

            // Create dirt
            void OnDirtExamined(object source, ExaminedEventArgs eventArgs)
            {
                // Set the anonymous coffin as visible
                otherCoffin.IsVisible = true;

                // Remove event handler
                ((PhysicalEntity)source).Examined -= OnDirtExamined;
            }

            var dirt = new PhysicalEntity("Dirt", "Mud");
            dirt.Examined += OnDirtExamined;
            dirt.SetActionResultMessage(ActionType.Examine, "The dirt is moisty and leads to a nearby anonymous coffin, where it abruptly ends.\nCurious.");
            dirt.SetActionResultMessage(ActionType.Take, "Please, don't try asking me to take EVERYTHING. Expecially mud.");
            dirt.SetActionResultMessage(ActionType.Eat, "... no.");
            AddChild(dirt);

            // Create entrance
            var entrance = new TransitionEntity("Entrance", "Exit", "Cemetery", "Out", "Outside", "Door", "Access")
            {
                DestinationId = RoomId.Cemetery
            };
            entrance.SetActionResultMessage(ActionType.Examine, "A feeble light enters through the entrance.\nWhile insufficient in enlightening the room, I can easily track the exit at least.");
            AddChild(entrance);

            // Create ceiling
            var ceiling = Common.CreateCeiling();
            ceiling.SetActionResultMessage(ActionType.Examine, "The crypt is small enough for the light to reach the ceiling.\nThat being said, there's nothing special about it.");
            AddChild(ceiling);

            // Create ground
            var ground = Common.CreateGround();
            ground.SetActionResultMessage(ActionType.Examine, "This stone brick floor must be really old, but it stood the test of time.\nWhile it's dirty overall, as to be expected, there's some very interesting fresh mud.");
            AddChild(ground);

            // Create view
            View = new RoomView(background);
        }
    }
    */
}