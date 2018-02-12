using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
	public class Tile : TileBase
	{
		public string Name => "tile";
		public override string ResourceName => $"{Name}";
	}
}
