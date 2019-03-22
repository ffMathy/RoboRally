using RoboRally.Core;
using RoboRally.Core.Cards;
using System.Windows;

namespace RoboRally.Sample.Windows.Tags
{
    class PlayerCardTag
    {
        public FrameworkElement Control { get; }

        public IPlayer Player { get; }
        public ICard Card { get; }

        public PlayerCardTag(
            FrameworkElement control,
            IPlayer player,
            ICard card)
        {
            Control = control;
            Player = player;
            Card = card;
        }
    }
}
