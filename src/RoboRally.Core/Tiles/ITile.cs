using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Tiles
{
    public interface ITile
    {
		ITileRelation Left { get; }
		ITileRelation Top { get; }
		ITileRelation Bottom { get; }
		ITileRelation Right { get; }

		int X { get; set; }
		int Y { get; set; }

		string ResourceName { get; }

		int MovePriority { get; }

		IRobot Robot { get; set; }
		IGame Game { get; set; }

		ITileModifier[] Modifiers { get; }

		void Move(int registerOffset);
		void TouchByRobot(IRobot robot);
	}
}
