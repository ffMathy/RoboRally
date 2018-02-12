using RoboRally.Core.Cards;

namespace RoboRally.Core
{
	class ProgramSheet : IProgramSheet
	{
		public int DamageTokenCount { get; set; }
		public int LifeTokenCount { get; set; }
		public bool IsPoweredDown { get; set; }

		public ICard[] RegisterCards { get; set; }
	}
}