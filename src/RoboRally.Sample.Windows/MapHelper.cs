using RoboRally.Core;
using RoboRally.Core.FactoryFloor;
using RoboRally.Core.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Sample
{
	public class MapHelper : IMapHelper
	{
		private static Func<ITile> conveyorBeltUpConstructor = () => new ConveyorBeltTile(OrientationDirection.Up);
		private static Func<ITile> conveyorBeltDownConstructor = () => new ConveyorBeltTile(OrientationDirection.Down);
		private static Func<ITile> conveyorBeltRightConstructor = () => new ConveyorBeltTile(OrientationDirection.Right);
		private static Func<ITile> conveyorBeltLeftConstructor = () => new ConveyorBeltTile(OrientationDirection.Left);

		private static Func<ITile> expressConveyorBeltUpConstructor = () => new ExpressConveyorBeltTile(OrientationDirection.Up);
		private static Func<ITile> expressConveyorBeltDownConstructor = () => new ExpressConveyorBeltTile(OrientationDirection.Down);
		private static Func<ITile> expressConveyorBeltRightConstructor = () => new ExpressConveyorBeltTile(OrientationDirection.Right);
		private static Func<ITile> expressConveyorBeltLeftConstructor = () => new ExpressConveyorBeltTile(OrientationDirection.Left);

		private static Func<ITile> tileConstructor = () => new Tile();

		private static Func<ITile> holeConstructor = () => new HoleTile();

		private readonly IFactoryFloorBuilderFactory _factoryFloorBuilderFactory;

		public MapHelper(IFactoryFloorBuilderFactory factoryFloorBuilderFactory)
		{
			_factoryFloorBuilderFactory = factoryFloorBuilderFactory;
		}

		public IFactoryFloor BuildExchangeMap()
		{
			IFactoryFloorBuilder builder = _factoryFloorBuilderFactory.Create(12, 12);

			int row;

			//row 0
			row = 0;
			builder.FillTile(0, row, tileConstructor());
			builder.FillTile(1, row, conveyorBeltDownConstructor());
			builder.FillTile(5, row, tileConstructor());

			//row 1
			row += 1;
			builder.FillTile(0, row, conveyorBeltLeftConstructor());
			builder.FillTile(1, row, new RotateRightTile());
			builder.FillTile(11, row, holeConstructor());

			//row 2
			row += 1;
			builder.FillTile(11, row, tileConstructor());

			//row 3
			row += 1;
			builder.FillTile(3, row, new RotateLeftTile());
			builder.FillTile(8, row, new RotateLeftTile());

			//row 4
			row += 1;

			//row 5
			row += 1;
			builder.FillTile(11, row, tileConstructor());

			//row 6
			row += 1;

			//row 7
			row += 1;

			//row 8
			row += 1;
			builder.FillTile(8, row, new RotateLeftTile());

			//row 9
			row += 1;

			//row 10
			row += 1;
			builder.FillTile(0, row, conveyorBeltRightConstructor());
			builder.FillTile(1, row, new RotateRightTile());
			builder.FillTile(9, row, holeConstructor());
			builder.FillTile(11, row, conveyorBeltRightConstructor());

			//row 11
			row += 1;
			builder.FillTile(0, row, tileConstructor());
			builder.FillTile(1, row, conveyorBeltDownConstructor());
			builder.FillTile(9, row, tileConstructor());
			builder.FillTile(11, row, tileConstructor());

			//repeated areas
			builder.FillVerticalArea(2, 0, 3, tileConstructor);
			builder.FillVerticalArea(3, 0, 3, conveyorBeltUpConstructor);
			builder.FillVerticalArea(4, 0, 5, tileConstructor);
			builder.FillVerticalArea(6, 0, 5, expressConveyorBeltUpConstructor);
			builder.FillVerticalArea(7, 0, 5, tileConstructor);
			builder.FillVerticalArea(8, 0, 3, conveyorBeltDownConstructor);
			builder.FillVerticalArea(9, 0, 3, tileConstructor);
			builder.FillHorizontalArea(10, 0, 2, tileConstructor);
			builder.FillVerticalArea(5, 1, 4, conveyorBeltDownConstructor);
			builder.FillVerticalArea(10, 1, 2, tileConstructor);
			builder.FillHorizontalArea(0, 2, 2, tileConstructor);
			builder.FillHorizontalArea(0, 3, 3, conveyorBeltRightConstructor);
			builder.FillHorizontalArea(9, 3, 3, conveyorBeltRightConstructor);
			builder.FillHorizontalArea(0, 4, 4, tileConstructor);
			builder.FillHorizontalArea(8, 4, 4, tileConstructor);
			builder.FillHorizontalArea(0, 5, 5, expressConveyorBeltLeftConstructor);
			builder.FillHorizontalArea(5, 5, 2, tileConstructor);
			builder.FillHorizontalArea(7, 5, 4, conveyorBeltLeftConstructor);
			builder.FillHorizontalArea(0, 6, 5, conveyorBeltRightConstructor);
			builder.FillHorizontalArea(5, 6, 2, tileConstructor);
			builder.FillHorizontalArea(7, 6, 5, conveyorBeltRightConstructor);
			builder.FillHorizontalArea(0, 7, 5, tileConstructor);
			builder.FillVerticalArea(5, 7, 5, conveyorBeltDownConstructor);
			builder.FillVerticalArea(6, 7, 5, conveyorBeltUpConstructor);
			builder.FillHorizontalArea(7, 7, 5, tileConstructor);
			builder.FillHorizontalArea(0, 8, 3, expressConveyorBeltLeftConstructor);
			builder.FillVerticalArea(3, 8, 4, conveyorBeltUpConstructor);
			builder.FillVerticalArea(4, 8, 4, tileConstructor);
			builder.FillVerticalArea(7, 8, 4, tileConstructor);
			builder.FillHorizontalArea(9, 8, 3, conveyorBeltLeftConstructor);
			builder.FillHorizontalArea(0, 9, 3, tileConstructor);
			builder.FillVerticalArea(8, 9, 3, conveyorBeltDownConstructor);
			builder.FillHorizontalArea(9, 9, 3, tileConstructor);
			builder.FillVerticalArea(2, 10, 2, tileConstructor);
			builder.FillVerticalArea(10, 10, 2, tileConstructor);

			return builder.Build();
		}
	}
}
