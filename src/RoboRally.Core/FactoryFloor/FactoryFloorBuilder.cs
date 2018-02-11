using RoboRally.Core.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.FactoryFloor
{
	class FactoryFloorBuilder : IFactoryFloorBuilder
	{
		private readonly IGame _game;

		public FactoryFloorBuilder(IGame game)
		{
			_game = game;
		}

		public void FillTile(
			int x,
			int y,
			ITile tile)
		{
			tile.Game = _game;
		}

		public void FillArea(
			int x,
			int y,
			int width,
			int height,
			Func<ITile> tileConstructor)
		{
			for (var currentX = x; currentX <= x + width; currentX++)
			{
				for (var currentY = y; currentY <= currentY + height; currentY++)
				{
					FillTile(currentX, currentY, tileConstructor());
				}
			}
		}

		public void FillHorizontalArea(int x, int y, int toX, Func<ITile> tileConstructor)
		{
			FillArea(x, y, toX, y, tileConstructor);
		}

		public void FillVerticalArea(int x, int y, int toY, Func<ITile> tileConstructor)
		{
			FillArea(x, y, x, toY, tileConstructor);
		}

		public IFactoryFloor Build()
		{
			throw new NotImplementedException();
		}
	}
}
