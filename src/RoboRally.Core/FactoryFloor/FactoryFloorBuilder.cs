using RoboRally.Core.Tiles;
using System;
using System.Collections.Generic;

namespace RoboRally.Core.FactoryFloor
{
    [Serializable]
    class FactoryFloorBuilder : IFactoryFloorBuilder
	{
		private readonly IGame _game;

		private readonly int _width;
		private readonly int _height;

		private readonly ITile[,] _tiles;

		public FactoryFloorBuilder(
			IGame game,
			int width,
			int height)
		{
			_game = game;

			_width = width;
			_height = height;

			_tiles = new ITile[width, height];
		}

		public void FillTile(
			int x,
			int y,
			ITile tile)
		{
			if (_tiles[x, y] != null)
				throw new InvalidOperationException(
					"Can't place a tile at position " + x + "," + y + " twice. There is already a " + _tiles[x, y].GetType().Name + " there.");

			_tiles[x, y] = tile;

			tile.Game = _game;

			UpdateAllTileRelations();
		}

		public void FillArea(
			int x,
			int y,
			int width,
			int height,
			Func<ITile> tileConstructor)
		{
			for (var currentX = x; currentX < x + width; currentX++)
			{
				for (var currentY = y; currentY < y + height; currentY++)
				{
					FillTile(currentX, currentY, tileConstructor());
				}
			}
		}

		public void FillHorizontalArea(int x, int y, int width, Func<ITile> tileConstructor)
		{
			FillArea(x, y, width, 1, tileConstructor);
		}

		public void FillVerticalArea(int x, int y, int height, Func<ITile> tileConstructor)
		{
			FillArea(x, y, 1, height, tileConstructor);
		}

		private void UpdateAllTileRelations()
		{
			for (var x = 0; x < _width; x++)
			{
				for (var y = 0; y < _height; y++)
				{
					var tile = _tiles[x, y];
					if (tile == null)
						continue;

					tile.X = x;
					tile.Y = y;

					if (x > 0)
						tile.Left.Tile = _tiles[x - 1, y];

					if (x < _width - 1)
						tile.Right.Tile = _tiles[x + 1, y];

					if (y > 0)
						tile.Top.Tile = _tiles[x, y - 1];

					if (y < _height - 1)
						tile.Bottom.Tile = _tiles[x, y + 1];
				}
			}
		}

		public IFactoryFloor Build()
		{
			for (var x = 0; x < _width; x++)
			{
				for (var y = 0; y < _height; y++)
				{
					var tile = _tiles[x, y];
					if (tile == null)
						throw new InvalidOperationException("The tile spot at " + x + "," + y + " has not been filled out.");
				}
			}

			var tilesSingleDimensional = new List<ITile>();
			foreach(var tile in _tiles) {
				tilesSingleDimensional.Add(tile);
			}

			return new FactoryFloor()
			{
				Tiles = tilesSingleDimensional.ToArray(),
				Width = _width,
				Height = _height
			};
		}
	}
}
