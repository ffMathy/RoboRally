using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
	public class ConveyorBeltTile : Tile
	{
		public OrientationDirection Direction { get; set; }

		public ConveyorBeltTile(OrientationDirection direction)
		{
			Direction = direction;
		}

		public override void BeforeMove(int registerOffset)
		{
			if (Robot == null)
				return;

			Game.MoveRobot(Robot, Direction);
		}

		public override void AfterMove(int registerOffset)
		{
			Game.AbsoluteRotateRobot(Robot, Direction);
		}
	}
}
