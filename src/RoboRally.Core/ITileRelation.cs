using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface ITileRelation
    {
		ITile Tile { get; }
	
		bool IsObstructed { get; }
	}
}
