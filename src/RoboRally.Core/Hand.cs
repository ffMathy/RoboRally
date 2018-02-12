using System;
using System.Collections.Generic;
using System.Text;
using RoboRally.Core.Cards;

namespace RoboRally.Core
{
	public class Hand : IHand
	{
		public ICard[] Cards { get; set; }

		public void AddCard(ICard card)
		{
			Cards[Cards.Length] = card;
		}
	}
}
