using RoboRally.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using FormsApplication = System.Windows.Forms.Application;

namespace RoboRally.Sample.Windows
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IGame _game;

		public MainWindow(IGame game)
		{
			InitializeComponent();
			_game = game;
			this.Width = 70 * _game.FactoryFloor.Width;
			this.Height = 70 * _game.FactoryFloor.Height;
			
			game.RenderRequested += Game_RenderRequested;
		}

		private void Game_RenderRequested()
		{
			Grid.ColumnDefinitions.Clear();
			Grid.RowDefinitions.Clear();

			for (var x = 0; x < _game.FactoryFloor.Width; x++)
				Grid.ColumnDefinitions.Add(new ColumnDefinition());
				
			for (var y = 0; y < _game.FactoryFloor.Width; y++)
				Grid.RowDefinitions.Add(new RowDefinition());

			for (var x = 0; x < _game.FactoryFloor.Width; x++)
			{
				for (var y = 0; y < _game.FactoryFloor.Width; y++)
				{
					var tile = _game.FactoryFloor.Tiles.First(t => t.X == x && t.Y == y);

					var tileImage = new Image();
					tileImage.Source = new BitmapImage(new Uri($"/Images/{tile.ResourceName}.png", UriKind.Relative));

					Grid.SetColumn(tileImage, x);
					Grid.SetRow(tileImage, y);

					Grid.Children.Add(tileImage);

					if(tile.Robot != null) {
						var robotImage = new Image();
						robotImage.Source = new BitmapImage(new Uri($"/Images/Robot_{tile.Robot.Direction}.png", UriKind.Relative));

						Grid.SetColumn(robotImage, x);
						Grid.SetRow(robotImage, y);

						Grid.Children.Add(robotImage);
					}
				}
			}

			FormsApplication.DoEvents();
			Thread.Sleep(500);
			FormsApplication.DoEvents();
		}
	}
}
