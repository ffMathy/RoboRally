﻿
namespace RoboRally.Core.Cards
{
    public class Rotate : ICard
    {
		public RotateDirection Direction { get; set; }
		public int Priority { get; set; }

		public IGame Game { get; set; }

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