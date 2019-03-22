using System;
using System.Diagnostics;

namespace RoboRally.Core.Tiles
{
    [Serializable]
    public class ConveyorBeltTile : TileBase
	{
		public override string ResourceName => $"ConveyorBelt_{Direction}";
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
