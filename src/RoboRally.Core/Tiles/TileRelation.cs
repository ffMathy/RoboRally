using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
	class TileRelation : ITileRelation
	{
		public bool IsObstructed => throw new NotImplementedException();

		public ITile Tile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}
