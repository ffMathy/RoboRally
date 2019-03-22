using RoboRally.Core.Tiles;
using System;

namespace RoboRally.Core.FactoryFloor
{
    [Serializable]
    class FactoryFloor : IFactoryFloor
	{
		public ITile[] Tiles { get; set; }

		public int Width { get; set; }
		public int Height { get; set; }

		public FactoryFloor()
		{

		}
	}
}
