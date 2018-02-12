using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using RoboRally.Core;
using RoboRally.Core.Cards;
using RoboRally.Core.FactoryFloor;
using RoboRally.Core.Tiles;

namespace RoboRally.Sample.Windows
{
	public static class Extensions
	{
		public static void AddAssemblyTypesAsImplementedInterfaces(this ServiceCollection serviceCollection, params Assembly[] assemblies)
		{
			foreach (var assembly in assemblies)
			{
				var classTypes = assembly
					.GetTypes()
					.Where(x => x.IsClass);
				foreach (var classType in classTypes)
				{
					var implementedInterfaceTypes = classType.GetInterfaces();
					foreach (var implementedInterfaceType in implementedInterfaceTypes)
					{
						serviceCollection.AddTransient(implementedInterfaceType, classType);
					}
				}
			}
		}
	}

	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddAssemblyTypesAsImplementedInterfaces(
				typeof(IGame).Assembly, 
				typeof(Program).Assembly);

			var serviceProvider = serviceCollection.BuildServiceProvider();
			
			var playerFactory = serviceProvider.GetService<IPlayerFactory>();

			var player1 = playerFactory.Create();
			var player2 = playerFactory.Create();
			
			var cardDeckFactory = serviceProvider.GetService<ICardDeckFactory>();
			var deck = cardDeckFactory.CreateDeck();
			
			var gameFactory = serviceProvider.GetService<IGameFactory>();
			var game = gameFactory.Create(new[] { player1, player2 });

			var mapHelper = serviceProvider.GetService<IMapHelper>();
			game.FactoryFloor = mapHelper.BuildExchangeMap();

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
