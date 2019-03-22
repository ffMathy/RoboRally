namespace RoboRally.Core
{
    public static class DirectionHelper
    {
		public static OrientationDirection GetRotatedDirection(OrientationDirection targetDirection, RotateDirection rotationDirection) {
			var newDirection = ((int)targetDirection + (int)rotationDirection) % 4;
			if(newDirection < 0)
				newDirection += 4;

			return (OrientationDirection)newDirection;
		}

		public static RotateDirection GetRotationDirection(OrientationDirection fromDirection, OrientationDirection toDirection) {
			var rotateDirection = (int)toDirection - (int)fromDirection;
			if(rotateDirection >= 3)
				rotateDirection -= 4;

			if(rotateDirection == -2)
				rotateDirection = (int)RotateDirection.Uturn;

			if(rotateDirection < -1)
				rotateDirection += 4;

			return (RotateDirection)rotateDirection;
		}
	}
}
