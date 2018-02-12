using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RoboRally.Core.Tiles
{
    public class RotateRightTile : TileBase
	{
		public string Name => "RotateRightTile";
		public override string ResourceName => $"{Name}";
		public override void Move(int registerOffset)
		{
			if (Robot == null)
				return;

			Debug.WriteLine(this + " move");
			Game.RotateRobot(Robot, RotateDirection.Right);
		}

		public override string ToString()
		{
			return "[Rotate right]";
		}
	}
}
