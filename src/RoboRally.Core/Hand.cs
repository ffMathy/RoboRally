using System;
using System.Collections.Generic;
using System.Text;
using RoboRally.Core.Cards;

namespace RoboRally.Core
{
	public class Hand : IHand
	{
		public IList<ICard> Cards { get; private set; }

		public Hand()
		{
			Cards = new List<ICard>();
		}
	}
}
