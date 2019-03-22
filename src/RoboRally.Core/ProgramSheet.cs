using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;

namespace RoboRally.Core
{
    [Serializable]
    class ProgramSheet : IProgramSheet
	{
		public int DamageTokenCount { get; set; }
		public int LifeTokenCount { get; set; }
		public bool IsPoweredDown { get; set; }

		public IList<ICard> RegisterCards { get; set; }

        public ProgramSheet()
        {
            RegisterCards = new List<ICard>();
        }
	}
}