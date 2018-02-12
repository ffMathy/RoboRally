using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
	public class ExpressConveyorBeltTile : ConveyorBeltTile
	{
		public ExpressConveyorBeltTile(OrientationDirection direction) : base(direction)
		{
		}

		public override void Move(int registerOffset)
		{
			base.Move(registerOffset);
			base.Move(registerOffset);
		}
	}
}
