﻿using System;
using System.Collections.Generic;
using RoboRally.Core.Cards;

namespace RoboRally.Core
{
    [Serializable]
    public class Hand : IHand
	{
		public IList<ICard> Cards { get; private set; }

		public Hand()
		{
			Cards = new List<ICard>();
		}
	}
}
