using RoboRally.Core.Cards;
using System.Collections.Generic;

namespace RoboRally.Core
{
    public interface IHand
    {
		IList<ICard> Cards { get; }
	}
}
