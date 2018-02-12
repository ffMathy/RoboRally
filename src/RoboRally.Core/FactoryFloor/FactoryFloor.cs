using System;
using System.Collections.Generic;
using System.Text;
using RoboRally.Core.Tiles;

namespace RoboRally.Core.FactoryFloor
{
	class FactoryFloor : IFactoryFloor
	{
		public ITile[] Tiles { get; set; }

		public FactoryFloor()
		{

		}
	}
}
