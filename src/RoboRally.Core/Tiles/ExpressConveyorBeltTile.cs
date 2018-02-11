using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
	public class ExpressConveyorBeltTile : Tile
	{
		public OrientationDirection Direction { get; set; }

		public ExpressConveyorBeltTile(OrientationDirection direction)
		{
			Direction = direction;
		}

		public override void BeforeMove(int registerOffset)
		{
			if (Robot == null)
				return;

			Game.MoveRobot(Robot, Direction);
			Game.MoveRobot(Robot, Direction);
		}

		public override void AfterMove(int registerOffset)
		{
			Game.RotateRobot(Robot, DirectionHelper.RotateDirection(Robot.Direction, ));
			Game.RelativeRotateRobot(Robot, Direction);
		}
	}
}
