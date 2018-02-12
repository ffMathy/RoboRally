using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Cards
{
    public class Uturn : ICard
    {
		public int Priority { get; set; }

		public IGame Game { get; set; }

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
