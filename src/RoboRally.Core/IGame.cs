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

		void MoveRobot(IRobot robot, Direction direction);
		void RotateRobot(IRobot robot, Direction direction);

		void FireLaser(IRobot robot);
		void KillRobot(IRobot robot);

		IDealProgramCardsPhase EnterDealProgramCardsPhase();
		IProgramRegistersPhase EnterProgramRegistersPhase();
		IAnnouncePowerDownPhase EnterAnnouncePowerDownPhase();
		ICompleteRegistersPhase EnterCompleteRegistersPhase();
		ICleanupPhase EnterCleanupPhase();
		
		void Initialize();
	}
}
