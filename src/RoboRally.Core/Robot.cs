﻿using RoboRally.Core.Tiles;
using System;

namespace RoboRally.Core
{
    [Serializable]
    class Robot : IRobot
	{
		public OrientationDirection Direction { get; set; }
		public ITile CurrentTile { get; set; }
		public ITile ArchiveMarkerPosition { get; set; }
		public IGame Game { get; set; }
		public IPlayer Player { get; set; }

		public ITile[] FlagsTouched { get; set; }

		public int LastMovedRegisterOffset { get; set; }

		public void FireLaser()
		{
			Game.FireLaser(this);
		}

		public override string ToString()
		{
			return Player.ToString();
		}
	}
}
