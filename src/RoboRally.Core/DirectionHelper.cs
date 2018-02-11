using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    class DirectionHelper
    {
		public static Direction RotateDirection(Direction targetDirection, RotateDirection direction) {
			return (Direction)(((int)targetDirection - (int)direction) % 4);
		}
	}
}
