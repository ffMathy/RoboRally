using RoboRally.Core.Tiles;

namespace RoboRally.Core.FactoryFloor
{
    public interface IFactoryFloor
    {
		ITile[] Tiles { get; }

		int Width { get; }
		int Height { get; }
	}
}
