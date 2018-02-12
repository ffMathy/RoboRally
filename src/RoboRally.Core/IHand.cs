using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface IHand
    {
		IList<ICard> Cards { get; }
	}
}
