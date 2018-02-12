using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboRally.Core.Tiles
{
	public class PusherTile : Tile
	{
		public override string Name => "pusher";

		public PusherTile()
		{
			ResourceName = $"{Name}_{Direction}";
		}
		public OrientationDirection Direction { get; set; }

		public int[] RegisterOffsets { get; set; }

		public override void Move(int registerOffset)
		{
			if (Robot == null)
				return;

			if (!RegisterOffsets.Contains(registerOffset))
				return;

			Game.MoveRobot(Robot, Direction);
		}
	}
}
