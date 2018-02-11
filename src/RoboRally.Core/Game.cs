using System;
using System.Collections.Generic;
using System.Text;
using RoboRally.Core.Phases;

namespace RoboRally.Core
{
	class Game : IGame
	{
		public IPlayer[] Players => throw new NotImplementedException();

		public IFactoryFloor FactoryFloor => throw new NotImplementedException();

		public ICardDeck CardDeck => throw new NotImplementedException();

		public IPhase CurrentPhase => throw new NotImplementedException();

		public IAnnouncePowerDownPhase EnterAnnouncePowerDownPhase()
		{
			throw new NotImplementedException();
		}

		public ICleanupPhase EnterCleanupPhase()
		{
			throw new NotImplementedException();
		}

		public ICompleteRegistersPhase EnterCompleteRegistersPhase()
		{
			throw new NotImplementedException();
		}

		public IDealProgramCardsPhase EnterDealProgramCardsPhase()
		{
			throw new NotImplementedException();
		}

		public IProgramRegistersPhase EnterProgramRegistersPhase()
		{
			throw new NotImplementedException();
		}

		public void Initialize()
		{

		}
	}
}
