using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RoboRally.Core.Cards;

namespace RoboRally.Core.Phases
{
    class ProgramRegistersPhase : IProgramRegistersPhase
	{
		private readonly IDictionary<IPlayer, IList<ICard>> _pendingCards;
        private readonly IGame _game;

        public ProgramRegistersPhase(
            IGame game)
		{
			_pendingCards = new Dictionary<IPlayer, IList<ICard>>();
            _game = game;
        }
		
		public void AddHandCardToProgramSheet(IPlayer player, ICard card)
		{
			GetPendingPlayerCards(player).Add(card);
		}

		public void RemoveCardFromProgramSheetToHand(IPlayer player, ICard card)
		{
			GetPendingPlayerCards(player).Remove(card);
		}

		private IList<ICard> GetPendingPlayerCards(IPlayer player) {
			if (!_pendingCards.ContainsKey(player))
				_pendingCards.Add(player, new List<ICard>());

			return _pendingCards[player];
		}

        public bool Step()
        {
            foreach(var player in _game.Players)
            {
                if (_pendingCards.ContainsKey(player) && _pendingCards[player].Count >= 5)
                    continue;

                Debug.WriteLine("Player " + player + " has not yet programmed all his/her cards.");
                return false;
            }

            foreach (var item in _pendingCards)
            {
                var player = item.Key;
                var cards = item.Value;

                player.ProgramSheet.RegisterCards = cards.ToArray();
            }

            return true;
        }

        public bool DoesProgramSheetContainCard(IPlayer player, ICard card)
        {
            return _pendingCards.ContainsKey(player) && _pendingCards[player].Contains(card);
        }
    }
}
