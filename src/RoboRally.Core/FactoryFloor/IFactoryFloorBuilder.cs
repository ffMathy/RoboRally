using System;
using RoboRally.Core.Tiles;

namespace RoboRally.Core.FactoryFloor
{
	public interface IFactoryFloorBuilder
	{
		IFactoryFloor Build();

		void FillArea(int x, int y, int width, int height, Func<ITile> tileConstructor);

		void FillHorizontalArea(int x, int y, int width, Func<ITile> tileConstructor);
		void FillVerticalArea(int x, int y, int height, Func<ITile> tileConstructor);

		void FillTile(int x, int y, ITile tile);
	}
}