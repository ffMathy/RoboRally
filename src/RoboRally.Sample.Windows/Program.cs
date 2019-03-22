using System;
using Microsoft.Extensions.DependencyInjection;
using RoboRally.Core;
using FluffySpoon.Extensions.MicrosoftDependencyInjection;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

namespace RoboRally.Sample.Windows
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            RegisterUriScheme();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAssemblyTypesAsImplementedInterfaces(
                typeof(IGame).Assembly,
                typeof(Program).Assembly);

            serviceCollection.AddSingleton(typeof(IGame), provider =>
            {
                var loadLink = args.FirstOrDefault();
                if (loadLink != null)
                {
                    try
                    {
                        loadLink = loadLink.Trim();

                        if (loadLink.StartsWith("roborally://"))
                            loadLink = loadLink.Substring("roborally://".Length);

                        loadLink = loadLink.Trim();

                        var bytes = Convert.FromBase64String(loadLink.Replace("_", "/").Replace("-", "+"));

                        var binaryFormatter = new BinaryFormatter();
                        using (var stream = new MemoryStream(bytes))
                        {
                            return (IGame)binaryFormatter.Deserialize(stream);
                        }
                    } catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        throw;
                    }
                }
                else
                {
                    var playerCount = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("How many players?", "Player count", "2", 0, 0));

                    var gameFactory = provider.GetService<IGameFactory>();
                    return gameFactory.Create(playerCount);
                }
            });

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var game = serviceProvider.GetService<IGame>();

            var mapHelper = serviceProvider.GetService<IMapHelper>();
            game.FactoryFloor = mapHelper.BuildExchangeMap();

            var playerFactory = serviceProvider.GetService<IPlayerFactory>();

            var tileToPlacePlayer = game.FactoryFloor.Tiles[0].Right.Tile.Right.Tile.Bottom.Tile.Bottom.Tile;
            foreach (var player in game.Players)
            {
                player.Robot.CurrentTile = tileToPlacePlayer;
                player.Robot.CurrentTile.Robot = player.Robot;

                tileToPlacePlayer = tileToPlacePlayer.Right.Tile.Bottom.Tile.Right.Tile;
            }

            var window = new GameWindow(game);
            window.Show();

            while (true)
            {
                Thread.Sleep(1);
                Application.DoEvents();
            }
        }
        private static void SetAssociation(string extension, string KeyName, string OpenWith, string FileDescription)
        {
            using (var currentUser = Registry.CurrentUser.OpenSubKey(
                "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + extension, true))
            {
                currentUser.DeleteSubKey("UserChoice", false);
            }

            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
    }
}
