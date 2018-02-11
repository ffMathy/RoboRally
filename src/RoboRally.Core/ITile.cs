using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface ITile
    {
		ITileRelation Left { get; }
		ITileRelation Top { get; }
		ITileRelation Bottom { get; }
		ITileRelation Right { get; }

		IRobot Robot { get; }
		ITileModifier[] Modifiers { get; }
	}
}
