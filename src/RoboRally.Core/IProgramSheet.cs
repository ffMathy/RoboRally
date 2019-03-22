using RoboRally.Core.Cards;
using System.Collections.Generic;

namespace RoboRally.Core
{
    public interface IProgramSheet
    {
		int DamageTokenCount { get; set; }
		int LifeTokenCount { get; set; }

		bool IsPoweredDown { get; set; }

		IList<ICard> RegisterCards { get; set; }
    }
}
