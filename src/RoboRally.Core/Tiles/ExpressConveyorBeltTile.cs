using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
    class ExpressConveyorBeltTile : TileBase
	{
		public Direction Direction { get; set; }

		public override void BeforeMove(int registerOffset)
		{
			if (Robot == null)
				return;

			Game.MoveRobot(Robot, Direction);
			Game.MoveRobot(Robot, Direction);
		}

		public override void AfterMove(int registerOffset)
		{
			Game.RotateRobot(Robot, Direction);
		}
	}
}
