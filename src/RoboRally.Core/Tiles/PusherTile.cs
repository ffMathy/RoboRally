using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace RoboRally.Core.Tiles
{
	public class PusherTile : TileBase
	{
		public string Name => "pusher";
		public override string ResourceName => $"{Name}_{Direction}";

		public OrientationDirection Direction { get; set; }

		public int[] RegisterOffsets { get; set; }

		public override void Move(int registerOffset)
		{
			if (Robot == null)
				return;

			if (!RegisterOffsets.Contains(registerOffset))
				return;

			Debug.WriteLine(this + " move");
			Game.MoveRobot(Robot, Direction);
		}

		public override string ToString()
		{
			return "[Pusher tile " + RegisterOffsets.Select(x => x.ToString()).Aggregate((a, b) => a + "," + b) + "]";
		}
	}
}
