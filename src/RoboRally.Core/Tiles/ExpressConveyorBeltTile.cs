using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RoboRally.Core.Tiles
{
	public class ExpressConveyorBeltTile : ConveyorBeltTile
	{
		public string Name => "ExpressConveyorBelt";
		public override string ResourceName => $"{Name}_{Direction}";
		public ExpressConveyorBeltTile(OrientationDirection direction) : base(direction)
		{

		}

		public override void Move(int registerOffset)
		{
			if (Robot == null)
				return;

			Debug.WriteLine(this + " move");

			var newConveyorBeltTile = Game.MoveRobot(Robot, Direction) as ConveyorBeltTile;
			if (newConveyorBeltTile == null)
				return;

			var rotationDirection = DirectionHelper.GetRotationDirection(Direction, newConveyorBeltTile.Direction);
			Game.RotateRobot(newConveyorBeltTile.Robot, rotationDirection);

			if (newConveyorBeltTile is ExpressConveyorBeltTile)
				Game.MoveRobot(newConveyorBeltTile.Robot, Direction);
		}

		public override string ToString()
		{
			return "[Express conveyor belt " + Direction + "]";
		}
	}
}
