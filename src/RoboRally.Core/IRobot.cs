using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface IRobot
    {
		Direction Direction { get; }
		ITile CurrentTile { get; }

		ITile[] FlagsTouched { get; }
		ITile ArchiveMarkerPosition { get; }

		void FireLaser();
	}
}
