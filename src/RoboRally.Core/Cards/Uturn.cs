using System;

namespace RoboRally.Core.Cards
{
    [Serializable]
    public class Uturn : ICard
    {
		public int Priority { get; set; }

		public IGame Game { get; set; }

        public string ResourceName => "u_turn";

        public void ExecuteOnBehalfOfPlayer(IPlayer player)
		{
			Game.RotateRobot(player.Robot, RotateDirection.Uturn);
		}

		public override string ToString()
		{
			return "[Uturn]";
		}
	}
}
