using System;
using System.Collections.Generic;

namespace RoboRally.Core.Cards
{

    class CardDeckFactory : ICardDeckFactory
	{
		public ICardDeck CreateDeck(IGame game)
		{
			var deckSetup = GetDeckSetup();

			var cards = new List<ICard>();
			foreach (var type in deckSetup)
			{
				var priority = type.StartPriority;

				while (priority <= type.EndPriority)
				{
					var card = type.CardConstructor();
					card.Priority = priority;
					card.Game = game;

					priority += type.PriorityModifier;
					cards.Add(card);
				}
			}

			var cardDeck = new CardDeck(cards);
			return cardDeck;
		}

		private IList<CardSetup> GetDeckSetup()
		{
			var cards = new List<CardSetup>();

			cards.Add(new CardSetup
			{
				CardConstructor = () => new Uturn(),
				StartPriority = 10, 
				EndPriority = 60, 
				PriorityModifier = 10
			});

			cards.Add(new CardSetup
			{
				CardConstructor = () => new Rotate
				{
					Direction = RotateDirection.Left
				},
				StartPriority = 70, 
				EndPriority = 410, 
				PriorityModifier = 20
			});

			cards.Add(new CardSetup
			{
				CardConstructor = () => new Rotate
				{
					Direction = RotateDirection.Right
				},
				StartPriority = 80, 
				EndPriority = 420, 
				PriorityModifier = 20
			});

			cards.Add(new CardSetup
			{
				CardConstructor = () => new Move
				{
					Direction = MoveDirection.Backward,
					Count = 1
				},
				StartPriority = 430, 
				EndPriority = 480, 
				PriorityModifier = 10
			});

			cards.Add(new CardSetup
			{
				CardConstructor = () => new Move
				{
					Direction = MoveDirection.Forward,
					Count = 1
				},
				StartPriority = 490, 
				EndPriority = 660, 
				PriorityModifier = 10
			});

			cards.Add(new CardSetup
			{
				CardConstructor = () => new Move
				{
					Direction = MoveDirection.Forward,
					Count = 2
				},
				StartPriority = 670, 
				EndPriority = 780, 
				PriorityModifier = 10
			});

			cards.Add(new CardSetup
			{
				CardConstructor = () => new Move
				{
					Direction = MoveDirection.Forward,
					Count = 3
				},
				StartPriority = 790, 
				EndPriority =  840, 
				PriorityModifier = 10
			});

			return cards;
		}
		private class CardSetup
		{
			public Func<ICard> CardConstructor { get; set; }

			public int StartPriority { get; set; }
			public int EndPriority { get; set; }
			public int PriorityModifier { get; set; }
		}
    }
}
