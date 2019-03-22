using System.Diagnostics;

namespace RoboRally.Core.Tiles
{
    public class ExpressConveyorBeltTile : ConveyorBeltTile
	{
		public override string ResourceName => $"ExpressConveyorBelt_{Direction}";
		public ExpressConveyorBeltTile(OrientationDirection direction) : base(direction)
		{

		}

		public override void Move(int registerOffset)
		{
			var robot = Robot;
			if (robot == null)
				return;

			Debug.WriteLine(this + " move");

			var newConveyorBeltTile = Game.MoveRobot(robot, Direction) as ConveyorBeltTile;
			if (newConveyorBeltTile == null)
				return;

			var rotationDirection = DirectionHelper.GetRotationDirection(Direction, newConveyorBeltTile.Direction);
			Game.RotateRobot(robot, rotationDirection);

			if (newConveyorBeltTile is ExpressConveyorBeltTile)
				Game.MoveRobot(robot, Direction);
		}

		public override string ToString()
		{
			return "[Express conveyor belt " + Direction + "]";
		}
	}
}
