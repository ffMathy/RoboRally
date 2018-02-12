using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		public override void Move(int registerOffset)
		{
			if (Robot == null)
				return;

			Debug.WriteLine(this + " move");

			var newConveyorBeltTile = Game.MoveRobot(Robot, Direction) as ConveyorBeltTile;
			if(newConveyorBeltTile == null)
				return;

			var rotationDirection = DirectionHelper.GetRotationDirection(Direction, newConveyorBeltTile.Direction);
			Game.RotateRobot(newConveyorBeltTile.Robot, rotationDirection);
		}

		public override string ToString()
		{
			return "[Conveyor belt " + Direction + "]";
		}
	}
}
