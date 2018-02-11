using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboRally.Core.Tiles
{
	public class PusherTile : Tile
	{
		public Direction Direction { get; set; }

		public int[] RegisterOffsets { get; set; }

		public override void BeforeMove(int registerOffset)
		{
			if (!RegisterOffsets.Contains(registerOffset))
				return;

			Game.MoveRobot(Robot, Direction);
		}
	}
}
