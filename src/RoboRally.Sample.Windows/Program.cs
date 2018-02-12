using System;
using System.Diagnostics;
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
					.Where(x => x.IsClass && !x.IsAbstract);
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
				
			serviceCollection.AddSingleton(typeof(IGame), provider =>
			{
				var gameFactory = provider.GetService<IGameFactory>();
				return gameFactory.Create(2);
			});

			var serviceProvider = serviceCollection.BuildServiceProvider();
			var game = serviceProvider.GetService<IGame>();

			var mapHelper = serviceProvider.GetService<IMapHelper>();
			game.FactoryFloor = mapHelper.BuildExchangeMap();

			var playerFactory = serviceProvider.GetService<IPlayerFactory>();

			var player1 = game.Players[0];
			var player2 = game.Players[1];

			var upperLeftTile = game.FactoryFloor.Tiles[0];

			player1.Robot.CurrentTile = upperLeftTile.Right.Tile.Right.Tile.Bottom.Tile.Bottom.Tile;
			player1.Robot.CurrentTile.Robot = player1.Robot;

			player2.Robot.CurrentTile = upperLeftTile.Right.Tile.Bottom.Tile.Bottom.Tile;
			player2.Robot.CurrentTile.Robot = player2.Robot;

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

				announcePowerDown.SetPowerDownState(player1, false);
				announcePowerDown.SetPowerDownState(player2, false);

				announcePowerDown.Commit();

				var completeRegisters = game.EnterCompleteRegistersPhase();
				completeRegisters.Commit();

				var cleanup = game.EnterCleanupPhase();
				cleanup.Commit();

				Debug.WriteLine("Simulating next turn.");

				Application.DoEvents();
			}
		}
	}
}
