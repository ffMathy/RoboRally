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
    public partial class GameWindow : Window
    {
        private readonly IGame _game;

        private const int TileSize = 60;

        public GameWindow(IGame game)
        {
            InitializeComponent();
            _game = game;

            Width = TileSize * _game.FactoryFloor.Width + 800;
            Height = TileSize * _game.FactoryFloor.Height;

            Left = 0;
            Top = 0;

            game.RenderRequested += Game_RenderRequested;

            _game.Step();

            KeyDown += GameWindow_KeyDown;

        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Space)
                return;

            e.Handled = true;
            _game.Step();
        }

        //private void GoToNextPhase()
        //{
        //    var dealProgramCards = _game.EnterDealProgramCardsPhase();
        //    dealProgramCards.Commit();

        //    var programRegisters = _game.EnterProgramRegistersPhase();
        //    foreach (var player in _game.Players)
        //    {
        //        programRegisters.AddHandCardToProgramSheet(player, player.Hand.Cards[0]);
        //        programRegisters.AddHandCardToProgramSheet(player, player.Hand.Cards[1]);
        //        programRegisters.AddHandCardToProgramSheet(player, player.Hand.Cards[2]);
        //        programRegisters.AddHandCardToProgramSheet(player, player.Hand.Cards[3]);
        //        programRegisters.AddHandCardToProgramSheet(player, player.Hand.Cards[4]);
        //    }

        //    programRegisters.Commit();

        //    var announcePowerDown = _game.EnterAnnouncePowerDownPhase();

        //    foreach (var player in _game.Players)
        //        announcePowerDown.SetPowerDownState(player, false);

        //    announcePowerDown.Commit();

        //    var completeRegisters = _game.EnterCompleteRegistersPhase();
        //    completeRegisters.Commit();

        //    var cleanup = _game.EnterCleanupPhase();
        //    cleanup.Commit();
        //}

        private void Game_RenderRequested()
        {
            RenderTiles();
            RenderHands();

            Delay(100);
        }

        private void RenderHands()
        {
            Hands.RowDefinitions.Clear();

            for (int i = 0; i < _game.Players.Length; i++)
            {
                var player = _game.Players[i];

                Hands.RowDefinitions.Add(new RowDefinition());

                var handPanel = new WrapPanel();
                handPanel.Orientation = Orientation.Horizontal;

                Grid.SetRow(handPanel, i);

                foreach (var card in player.Hand.Cards)
                {
                    var cardImage = new Image();
                    cardImage.Height = TileSize * 2;
                    cardImage.Source = new BitmapImage(
                        new Uri($"file://{Environment.CurrentDirectory}/Images/Cards/{card.ResourceName}.png",
                        UriKind.Absolute));

                    handPanel.Children.Add(cardImage);
                }

                Hands.Children.Add(handPanel);
            }
        }

        private void RenderTiles()
        {
            Tiles.ColumnDefinitions.Clear();
            Tiles.RowDefinitions.Clear();

            for (var x = 0; x < _game.FactoryFloor.Width; x++)
                Tiles.ColumnDefinitions.Add(new ColumnDefinition());

            for (var y = 0; y < _game.FactoryFloor.Width; y++)
                Tiles.RowDefinitions.Add(new RowDefinition());

            for (var x = 0; x < _game.FactoryFloor.Width; x++)
            {
                for (var y = 0; y < _game.FactoryFloor.Width; y++)
                {
                    var tile = _game.FactoryFloor.Tiles.First(t => t.X == x && t.Y == y);

                    var tileImage = new Image();
                    tileImage.Width = TileSize;
                    tileImage.Height = TileSize;
                    tileImage.Source = new BitmapImage(
                        new Uri($"file://{Environment.CurrentDirectory}/Images/Tiles/{tile.ResourceName}.png",
                        UriKind.Absolute));

                    Grid.SetColumn(tileImage, x);
                    Grid.SetRow(tileImage, y);

                    Tiles.Children.Add(tileImage);

                    if (tile.Robot != null)
                    {
                        RenderRobotImage(x, y, tile);
                        RenderPlayerLabel(x, y, tile.Robot.Player);
                    }
                }
            }
        }

        private void RenderPlayerLabel(int x, int y, IPlayer player)
        {
            var label = new TextBlock();
            label.Text = player.Label;
            label.Foreground = Brushes.Blue;
            label.FontSize = 30;
            label.FontWeight = FontWeights.Bold;
            label.TextAlignment = TextAlignment.Center;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;

            Grid.SetColumn(label, x);
            Grid.SetRow(label, y);

            Tiles.Children.Add(label);
        }

        private void RenderRobotImage(int x, int y, Core.Tiles.ITile tile)
        {
            var robotImage = new Image();
            robotImage.Width = TileSize;
            robotImage.Height = TileSize;
            robotImage.Source = new BitmapImage(
                new Uri($"file://{Environment.CurrentDirectory}/Images/Tiles/Robot_{tile.Robot.Direction}.png",
                UriKind.Absolute));

            Grid.SetColumn(robotImage, x);
            Grid.SetRow(robotImage, y);

            Tiles.Children.Add(robotImage);
        }

        private static void Delay(int milliseconds)
        {
            Thread.Sleep(milliseconds);
            FormsApplication.DoEvents();
        }
    }
}
