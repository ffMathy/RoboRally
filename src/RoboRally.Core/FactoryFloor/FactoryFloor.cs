using RoboRally.Core.Tiles;

namespace RoboRally.Core.FactoryFloor
{
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
