using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
	class TileBase : ITile
	{
		public ITileRelation Left { get; set; }
		public ITileRelation Top { get; set; }
		public ITileRelation Bottom { get; set; }
		public ITileRelation Right { get; set; }

		public int MovePriority { get; set; }

		public IRobot Robot { get; set; }

		public ITileModifier[] Modifiers { get; set; }

		public virtual void Move(int registerOffset)
		{
		}

		public virtual void TouchByRobot(IRobot robot)
		{
		}
	}
}
