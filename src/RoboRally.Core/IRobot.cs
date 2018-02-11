using RoboRally.Core.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface IRobot
    {
		IGame Game { get; }
		OrientationDirection Direction { get; }
		ITile CurrentTile { get; }
		ITile ArchiveMarkerPosition { get; }

		ITile[] FlagsTouched { get; }

		void FireLaser();
	}
}
