using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoboRally.Core.Cards;

namespace RoboRally.Core.Phases
{
	class ProgramRegistersPhase : IProgramRegistersPhase
	{
		private readonly IDictionary<IPlayer, IList<ICard>> _pendingCards;

		public ProgramRegistersPhase()
		{
			_pendingCards = new Dictionary<IPlayer, IList<ICard>>();
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
            foreach (var item in _pendingCards)
            {
                var player = item.Key;
                var cards = item.Value;

                player.ProgramSheet.RegisterCards = cards.ToArray();
            }

            return true;
        }
    }
}
