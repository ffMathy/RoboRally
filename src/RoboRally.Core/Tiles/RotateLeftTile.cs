using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
    public class RotateLeftTile : Tile
    {
		public string Name => "RotateLeftTile";
		public override string ResourceName => $"{Name}";
		public override void Move(int registerOffset)
		{
			if (Robot == null)
				return;

			Game.RotateRobot(Robot, RotateDirection.Left);
		}
	}
}
