using System;
using RoboRally.Core;
using RoboRally.Core.FactoryFloor;
using RoboRally.Core.Tiles;

namespace RoboRally.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
			IGame game = null;
			PopulateFactoryFloorWithExchangeMap(game);

			IPlayer player1 = null;
			IPlayer player2 = null;

			while (true)
			{
				var dealProgramCards = game.EnterDealProgramCardsPhase();
				dealProgramCards.Commit();

				var programRegisters = game.EnterProgramRegistersPhase();

				programRegisters.AddHandCardToProgramSheet(player1, player1.Hand.Cards[0]);
				programRegisters.AddHandCardToProgramSheet(player1, player1.Hand.Cards[1]);
				programRegisters.AddHandCardToProgramSheet(player1, player1.Hand.Cards[2]);
				programRegisters.AddHandCardToProgramSheet(player1, player1.Hand.Cards[3]);
				programRegisters.AddHandCardToProgramSheet(player1, player1.Hand.Cards[4]);

				programRegisters.AddHandCardToProgramSheet(player2, player2.Hand.Cards[0]);
				programRegisters.AddHandCardToProgramSheet(player2, player2.Hand.Cards[1]);
				programRegisters.AddHandCardToProgramSheet(player2, player2.Hand.Cards[2]);
				programRegisters.AddHandCardToProgramSheet(player2, player2.Hand.Cards[3]);
				programRegisters.AddHandCardToProgramSheet(player2, player2.Hand.Cards[4]);

				programRegisters.Commit();

				var announcePowerDown = game.EnterAnnouncePowerDownPhase();

				announcePowerDown.SetPowerDownState(player1, true);
				announcePowerDown.SetPowerDownState(player2, false);

				announcePowerDown.Commit();

				var completeRegisters = game.EnterCompleteRegistersPhase();
				completeRegisters.Commit();

				var cleanup = game.EnterCleanupPhase();
				cleanup.Commit();
			}
        }

		private static void PopulateFactoryFloorWithExchangeMap(IGame game)
		{
			IFactoryFloorBuilder builder = null;
			
			//row 1
			var row = 0;
			builder.FillTile(0, row, new Tile());
			builder.FillTile(1, row, new ConveyorBeltTile(OrientationDirection.Down));
			builder.FillTile(5, row, new Tile());

			//row 2
			row += 1;
			builder.FillTile(0, row, new ConveyorBeltTile(OrientationDirection.Left));
			builder.FillTile(1, row, new RotateRightTile());
			builder.FillTile(11, row, new HoleTile());

			//row 3
			row += 1;

			//row 4
			row += 1;
			builder.FillTile(3, row, new RotateLeftTile());
			builder.FillTile(8, row, new RotateLeftTile());
			
			//row 5
			row += 1;

			//row 6
			row += 1;
			builder.FillTile(11, row, new Tile());

			//row 7
			row += 1;

			//row 8
			row += 1;

			//row 9
			row += 1;
			builder.FillTile(8, row, new RotateLeftTile());

			//row 10
			row += 1;

			//row 11
			row += 1;
			builder.FillTile(0, row, new ConveyorBeltTile(OrientationDirection.Right));
			builder.FillTile(1, row, new RotateRightTile());
			builder.FillTile(9, row, new HoleTile());
			builder.FillTile(11, row, new ConveyorBeltTile(OrientationDirection.Right));

			//row 12
			row += 1;
			builder.FillTile(1, row, new ConveyorBeltTile(OrientationDirection.Down));

			//repeated areas
			builder.FillVerticalArea(2, 0, 3, () => new Tile());
			builder.FillVerticalArea(3, 0, 3, () => new ConveyorBeltTile(OrientationDirection.Up));
			builder.FillVerticalArea(4, 0, 4, () => new Tile());
			builder.FillVerticalArea(6, 0, 5, () => new ExpressConveyorBeltTile(OrientationDirection.Up));
			builder.FillVerticalArea(7, 0, 5, () => new Tile());
			builder.FillVerticalArea(8, 0, 3, () => new ConveyorBeltTile(OrientationDirection.Down));
			//builder.FillVerticalArea(8, 0, 3, () => new Tile());

			game.FactoryFloor = builder.Build();
		}
	}
}
