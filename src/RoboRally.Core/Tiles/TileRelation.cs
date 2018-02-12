using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
	class TileRelation : ITileRelation
	{
		public bool IsObstructed { get; set; }

		public ITile Tile { get; set; }
	}
}
