using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Cards
{
	public class Move : ICard
	{
		public MoveDirection Direction { get; set; }

		public int Priority { get; set; }
		public int Count { get; set; }

		public IGame Game { get; set; }

		public void ExecuteOnBehalfOfPlayer(IPlayer player)
		{
			for (var i = 0; i < Count; i++)
				Game.MoveRobot(player.Robot, player.Robot.Direction);
		}

		public override string ToString()
		{
			return "[Move " + Direction + " " + Count + "]";
		}
	}
}
