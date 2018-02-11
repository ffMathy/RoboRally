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

		int MovePriority { get; }

		IRobot Robot { get; }
		IGame Game { get; set; }

		ITileModifier[] Modifiers { get; }

		void BeforeMove(int registerOffset);
		void AfterMove(int registerOffset);

		void TouchByRobot(IRobot robot);
	}
}
