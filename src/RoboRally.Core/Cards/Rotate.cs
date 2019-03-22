
using System;

namespace RoboRally.Core.Cards
{
    [Serializable]
    public class Rotate : ICard
    {
		public RotateDirection Direction { get; set; }
		public int Priority { get; set; }

		public IGame Game { get; set; }

        public string ResourceName
        {
            get
            {
                if (Direction == RotateDirection.Left)
                    return "rotate_left";

                if (Direction == RotateDirection.Right)
                    return "rotate_right";

                throw new InvalidOperationException("Unknown rotate direction.");
            }
        }

        public void ExecuteOnBehalfOfPlayer(IPlayer player)
		{
			Game.RotateRobot(player.Robot, RotateDirection.Left);
		}

		public override string ToString()
		{
			return "[Rotate " + Direction + "]";
		}
	}
}
