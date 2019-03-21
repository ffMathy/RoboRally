using RoboRally.Core.Cards;
using RoboRally.Core.FactoryFloor;
using RoboRally.Core.Phases;
using RoboRally.Core.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface IGame
    {
		event Action RenderRequested;

		IPlayer[] Players { get; }

		IFactoryFloor FactoryFloor { get; set; }
		ICardDeck CardDeck { get; }

		IPhase CurrentPhase { get; }

		ITile MoveRobot(IRobot robot, OrientationDirection direction);

		void RotateRobot(IRobot robot, RotateDirection direction);

		void FireLaser(IRobot robot);
		void KillRobot(IRobot robot);

		IDealProgramCardsPhase EnterDealProgramCardsPhase();
		IProgramRegistersPhase EnterProgramRegistersPhase();
		IAnnouncePowerDownPhase EnterAnnouncePowerDownPhase();
		ICompleteRegistersPhase EnterCompleteRegistersPhase();
		ICleanupPhase EnterCleanupPhase();

        void Step();
	}
}
