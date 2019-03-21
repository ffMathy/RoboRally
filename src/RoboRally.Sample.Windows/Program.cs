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
using FluffySpoon.Extensions.MicrosoftDependencyInjection;
using System.Threading.Tasks;
using System.Threading;

namespace RoboRally.Sample.Windows
{
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

            var window = new GameWindow(game);
            window.Show();

            while (true)
            {
                Thread.Sleep(1);
                Application.DoEvents();
            }
        }
    }
}
