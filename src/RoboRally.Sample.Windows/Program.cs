using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using RoboRally.Core;
using RoboRally.Core.Cards;
using RoboRally.Core.FactoryFloor;
using RoboRally.Core.Tiles;

namespace RoboRally.Sample.Windows
{
    class Program
    {
        static void Main(string[] args)
        {
			var serviceCollection = new ServiceCollection();
			serviceCollection.

			var serviceProvider = serviceCollection.BuildServiceProvider();

			MapHelper.BuildExchangeMap();

			var cardDeckFactory = new CardDeckFactory();

			IPlayer player1 = null;
			IPlayer player2 = null;

			IPlayer[] players = null;

			var deck = cardDeckFactory.CreateDeck();

			IGame game = new Game(deck, players);
			game.FactoryFloor = MapHelper.BuildExchangeMap();

			var window = new MainWindow(game);
			window.Show();

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

				Console.WriteLine("Press any key to simulate next turn.");
				Console.ReadLine();

				Application.DoEvents();
			}
        }
	}
}
