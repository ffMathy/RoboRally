using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface IProgramSheet
    {
		int DamageTokenCount { get; set; }
		int LifeTokenCount { get; }

		bool IsPoweredDown { get; }

		ICard[] RegisterCards { get; }
    }
}
