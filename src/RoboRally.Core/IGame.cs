using RoboRally.Core.Cards;
using RoboRally.Core.Phases;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface IGame
    {
		IPlayer[] Players { get; }
		IFactoryFloor FactoryFloor { get; }
		ICardDeck CardDeck { get; }

		IPhase CurrentPhase { get; }
		
		IDealProgramCardsPhase EnterDealProgramCardsPhase();
		IProgramRegistersPhase EnterProgramRegistersPhase();
		IAnnouncePowerDownPhase EnterAnnouncePowerDownPhase();
		ICompleteRegistersPhase EnterCompleteRegistersPhase();
		ICleanupPhase EnterCleanupPhase();
		
		void Initialize();

		void FireLaser(IRobot robot);
	}
}
