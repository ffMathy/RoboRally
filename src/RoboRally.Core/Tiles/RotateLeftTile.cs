using System.Diagnostics;

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
