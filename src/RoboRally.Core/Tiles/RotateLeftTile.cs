using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RoboRally.Core.Tiles
{
    public class RotateLeftTile : TileBase
	{
		public override string ResourceName => $"RotateLeftTile";

		public override void Move(int registerOffset)
		{
			if (Robot == null)
				return;

			Debug.WriteLine(this + " move");
			Game.RotateRobot(Robot, RotateDirection.Left);
		}

		public override string ToString()
		{
			return "[Rotate left]";
		}
	}
}
