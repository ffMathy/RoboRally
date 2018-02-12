using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
	class TileRelation : ITileRelation
	{
		private bool _isObstructed;

		public bool IsObstructed { 
			get => _isObstructed || Tile == null; 
			set => _isObstructed = value; 
		}

		public ITile Tile { get; set; }
	}
}
