using RoboRally.Core.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.FactoryFloor
{
    public interface IFactoryFloor
    {
		ITile[] Tiles { get; }

		int Width { get; }
		int Height { get; }
	}
}
