using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
	public abstract class TileBase : ITile
	{
		public ITileRelation Left { get; set; }
		public ITileRelation Top { get; set; }
		public ITileRelation Bottom { get; set; }
		public ITileRelation Right { get; set; }

		public int MovePriority { get; set; }

		public IRobot Robot { get; set; }
		public IGame Game { get; set; }

		public ITileModifier[] Modifiers { get; set; }

		public int X { get; set; }
		public int Y { get; set; }

		public abstract string ResourceName { get; set; }

		public TileBase()
		{
			Left = new TileRelation();
			Top = new TileRelation();
			Right = new TileRelation();
			Bottom = new TileRelation();
		}

		public virtual void Move(int registerOffset)
		{
		}

		public virtual void TouchByRobot(IRobot robot)
		{
		}
	}
}
