using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
	public class HoleTile : Tile
	{
		public override string Name => "Hole";
		public override string ResourceName => $"{Name}";

		public override void TouchByRobot(IRobot robot)
		{
			Game.KillRobot(robot);
		}
	}
}
