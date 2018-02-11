using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
	public class ConveyorBeltTile : Tile
	{
		public Direction Direction { get; set; }

		public ConveyorBeltTile(Direction direction)
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
