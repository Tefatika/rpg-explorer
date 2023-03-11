using Microsoft.Xna.Framework.Graphics;
using RPGExplorer.Actions;
using RPGExplorer.Entities;
using RPGExplorer.Interfaces;
using RPGExplorer.View;

namespace RPGExplorer.Rooms
{
    /*
    class NearChurchRoom : Room
    {
        // Constants
        private const string RoomDescription = "This old building is still inhabited by the caretaker, even if nobody attends church anymore.";
        private const string RoomFirstTimeDescription = "The darkness of the night makes this place even creepier than it normally is. The church is in a miserable state and has been mostly abandoned by our community.\n" + RoomDescription;

        // Constants
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

        public NearChurchRoom(Texture2D background) : base("Near the church")
        {
            // Add window
            void OnWindowOpening(object sender, OpeningEventArgs e)
            {
                if (!((OpenableTransitionEntity)sender).IsOpen)
                {
                    e.Cancel = true;
                    e.Perceptor?.Perceive(new Stimulus("I can't open the window from this side."));
                }
            }

            void OnWindowBeenHit(object sender, BeenHitEventArgs e)
            {
                var wnd = (OpenableTransitionEntity)sender;

                wnd.SetActionResultMessage(ActionType.Examine, "This is one of the windows of the church.\nPeeking in I can see some lights - maybe the caretaker is inside.\nThe window has been broken.");
                wnd.CurrentRoom.DispatchStimulus(new Stimulus("*CRASH*"));
                wnd.Opening -= OnWindowOpening;
                wnd.BeenHit -= OnWindowBeenHit;
            }

            var window = new OpenableTransitionEntity("Window", "Glass", "In", "Inside")
            {
                DestinationId = RoomId.Church1F
            };
            window.Opening += OnWindowOpening;
            window.BeenHit += OnWindowBeenHit;
            window.SetActionResultMessage(ActionType.Examine, "This is one of the windows of the church.\nPeeking in I can see some lights - maybe the caretaker is inside.");
            AddChild(window);

            // Add entrance
            var entrance = new OpenableTransitionEntity("Door", "Entrance", "Entry", "Ingress", "Doorway", "Entryway", "Access", "In", "Inside")
            {
                DestinationId = RoomId.Church1F
            };
            entrance.SetActionResultMessage(ActionType.Examine, "This old and weathered wooden door is the only entrance to the church.");
            AddChild(entrance);

            // Add shovel
            var shovel = new PhysicalEntity("Shovel", "Spade", "Scoop")
            {
                CanBeTaken = true
            };
            AddChild(shovel);

            // Add sky
            AddChild(Common.CreateSky());

            // Create ground
            AddChild(Common.CreateCemeteryGround());

            // Create puddle
            AddChild(Common.CreateCemeteryPuddle());

            // Add cemetery
            var cemetery = new TransitionEntity("Cemetery")
            {
                DestinationId = RoomId.Cemetery
            };
            cemetery.SetActionResultMessage(ActionType.Examine, "Yep. That's the cemetery.\nJust graves and dead trees. So cliché.");
            AddChild(cemetery);

            // Create view
            View = new RoomView(background);
        }
    }
    */
}