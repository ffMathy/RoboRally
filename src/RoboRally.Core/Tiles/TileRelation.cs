using System;

namespace RoboRally.Core.Tiles
{
    [Serializable]
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
