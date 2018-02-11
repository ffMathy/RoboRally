﻿using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
    public class RotateLeftTile : Tile
    {
		public override void BeforeMove(int registerOffset)
		{
			Game.RotateRobot(Robot, RotateDirection.Left);
		}
	}
}
