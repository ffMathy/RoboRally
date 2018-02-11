using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{

	public class CardDeckFactory : ICardDeckFactory
	{
		public ICardDeck CreateDeck()
		{
			var deckSetup = GetDeckSetup();

			var cardDeck = new CardDeck();
			foreach (var type in deckSetup)
			{
				var next = type.Value[0];
				var modifier = type.Value[1];
				var end = type.Value[2];
				while (next <= end)
				{
					next += modifier;
				}
			}

			return cardDeck;
		}

		private IDictionary<ICard, List<int>> GetDeckSetup()
		{
			var cards = new Dictionary<ICard, List<int>>();

			cards.Add(new Uturn(), 
			new List<int>
			{
				10, // Start index
				60, // End index
				10 // modifier
			});

			cards.Add(new Rotate { Direction = RotateDirection.Left },
			new List<int>
			{
				70, // Start index
				410, // End index
				20 // modifier
			});

			cards.Add(new Rotate { Direction = RotateDirection.Right },
			new List<int>
			{
				80, // Start index
				420, // End index
				20 // modifier
			});

			cards.Add(new Move { MoveDirection = MoveDirection.Backward, Count = 1 },
			new List<int>
			{
				430, // Start index
				480, // End index
				10 // modifier
			});

			cards.Add(new Move { MoveDirection = MoveDirection.Backward, Count = 1 },
			new List<int>
			{
				490, // Start index
				660, // End index
				10 // modifier
			});

			cards.Add(new Move { MoveDirection = MoveDirection.Backward, Count = 2 },
			new List<int>
			{
				670, // Start index
				780, // End index
				10 // modifier
			});

			cards.Add(new Move { MoveDirection = MoveDirection.Backward, Count = 3 },
			new List<int>
			{
				790, // Start index
				840, // End index
				10 // modifier
			});

			return cards;
		}
    }
}
