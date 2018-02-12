using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
    public interface ITileRelation
    {
		ITile Tile { get; set; }
	
		bool IsObstructed { get; }
	}
}
