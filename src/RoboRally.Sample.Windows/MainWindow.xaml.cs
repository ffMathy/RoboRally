using RoboRally.Core;
using RoboRally.Core.Phases;
using RoboRally.Sample.Windows.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RoboRally.Sample.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private IGame _game;

        private readonly IList<Image> _imageElements;
        private readonly BinaryFormatter _binaryFormatter;

        private const int TileSize = 60;

        public GameWindow(IGame game)
        {
            InitializeComponent();

            _game = game;

            _imageElements = new List<Image>();
            _binaryFormatter = new BinaryFormatter();

            Width = TileSize * _game.FactoryFloor.Width + 800;
            Height = TileSize * _game.FactoryFloor.Height;

            Left = 0;
            Top = 0;

            game.RenderRequested += PerformRender;

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

        private void PerformRender()
        {
            foreach (var image in _imageElements)
            {
                image.MouseDown -= CardImageClicked;

                image.Source = null;
            }

            _imageElements.Clear();

            RenderTiles();
            RenderHands();
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
                    var grid = new Grid();

                    var programRegistersPhase = _game.CurrentPhase as IProgramRegistersPhase;

                    var isCardInProgramRegister =
                        programRegistersPhase != null &&
                        programRegistersPhase.DoesProgramSheetContainCard(player, card);

                    var cardImage = new Image
                    {
                        Height = TileSize * 2,
                        Source = GetImageFromEmbeddedResource($"/Images/Cards/{card.ResourceName}.png")
                    };
                    cardImage.Tag = new PlayerCardTag(
                        cardImage,
                        player,
                        card);

                    cardImage.MouseDown += CardImageClicked;

                    grid.Children.Add(cardImage);

                    _imageElements.Add(cardImage);

                    if (isCardInProgramRegister)
                    {
                        var overlayImage = new Image();
                        overlayImage.Opacity = 0.5;
                        overlayImage.Height = cardImage.Height;
                        overlayImage.Source = GetImageFromEmbeddedResource("/Images/Cards/hidden.png");
                        overlayImage.Tag = new PlayerCardTag(
                            cardImage,
                            player,
                            card);

                        overlayImage.MouseDown += CardImageClicked;

                        grid.Children.Add(overlayImage);

                        _imageElements.Add(overlayImage);
                    }

                    handPanel.Children.Add(grid);
                }

                Hands.Children.Add(handPanel);
            }
        }

        private void CardImageClicked(object sender, MouseButtonEventArgs e)
        {
            var element = (FrameworkElement)sender;
            var tag = (PlayerCardTag)element.Tag;

            var programRegistersPhase = _game.CurrentPhase as IProgramRegistersPhase;
            if (programRegistersPhase != null)
            {
                var isAlreadyProgrammed = programRegistersPhase.DoesProgramSheetContainCard(
                    tag.Player,
                    tag.Card);
                if (isAlreadyProgrammed)
                {
                    programRegistersPhase.RemoveCardFromProgramSheetToHand(
                        tag.Player,
                        tag.Card);
                }
                else
                {
                    programRegistersPhase.AddHandCardToProgramSheet(
                        tag.Player,
                        tag.Card);
                }
            }

            RenderHands();
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

                    RenderImageOnTile(x, y, $"/Tiles/{tile.ResourceName}.png");

                    if (tile.Robot != null)
                    {
                        RenderRobotImage(x, y, tile);
                        RenderPlayerLabel(x, y, tile.Robot.Player);
                    }
                }
            }
        }

        private void AddControlToTile(int x, int y, UIElement control)
        {
            Grid.SetColumn(control, x);
            Grid.SetRow(control, y);

            Tiles.Children.Add(control);
        }

        private void RenderPlayerLabel(int x, int y, IPlayer player)
        {
            var label = new TextBlock
            {
                Text = player.Label,
                Foreground = Brushes.Blue,
                FontSize = 30,
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            AddControlToTile(x, y, label);
        }

        private void RenderRobotImage(int x, int y, Core.Tiles.ITile tile)
        {
            RenderImageOnTile(x, y, $"/Tiles/Robot_{tile.Robot.Direction}.png");
        }

        private BitmapImage GetImageFromEmbeddedResource(string path)
        {
            var bitmap = new BitmapImage();
            var paths = typeof(GameWindow).Assembly.GetManifestResourceNames();

            if (path.StartsWith("/"))
                path = path.Substring(1);

            path = $"{nameof(RoboRally)}.{nameof(Sample)}.{nameof(Windows)}." + path.Replace("/", ".");

            using (var stream = typeof(GameWindow).Assembly.GetManifestResourceStream(path))
            {
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                bitmap.Freeze();
            }

            return bitmap;
        }

        private void RenderImageOnTile(int x, int y, string relativeImagePath)
        {
            var image = new Image
            {
                Width = TileSize,
                Height = TileSize,
                Source = GetImageFromEmbeddedResource($"/Images{relativeImagePath}")
            };

            AddControlToTile(x, y, image);

            _imageElements.Add(image);
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            using (var stream = new MemoryStream())
            {
                _game.RenderRequested -= PerformRender;
                _binaryFormatter.Serialize(stream, _game);
                _game.RenderRequested += PerformRender;

                var bytes = stream.ToArray();
                var text = Convert.ToBase64String(bytes);

                Clipboard.SetText("roborally://" + text.Replace("/", "_").Replace("+", "-"));
                MessageBox.Show("Game saved to clipboard!");
            }
        }
    }
}
