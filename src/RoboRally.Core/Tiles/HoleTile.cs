using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
	class HoleTile : TileBase
	{
		public override void TouchByRobot(IRobot robot)
		{
			Game.KillRobot(robot);
		}
	}
}
