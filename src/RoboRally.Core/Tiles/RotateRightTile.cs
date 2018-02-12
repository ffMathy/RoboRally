﻿using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
    public class RotateRightTile : Tile
    {
		public override string Name => "RotateRightTile";
		public override string ResourceName => $"{Name}";
		public override void Move(int registerOffset)
		{
			if (Robot == null)
				return;

			Game.RotateRobot(Robot, RotateDirection.Right);
		}
	}
}
