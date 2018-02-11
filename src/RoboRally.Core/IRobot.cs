using RoboRally.Core.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface IRobot
    {
		IGame Game { get; }
		IPlayer Player { get; }
		OrientationDirection Direction { get; set; }
		ITile CurrentTile { get; set; }
		ITile ArchiveMarkerPosition { get; }

		ITile[] FlagsTouched { get; }

		void FireLaser();
	}
}
