using System;
using System.Diagnostics;

namespace RoboRally.Core.Tiles
{
    [Serializable]
    public class RotateRightTile : TileBase
	{
		public override string ResourceName => $"RotateRightTile";

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
