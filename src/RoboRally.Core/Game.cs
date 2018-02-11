using System;
using System.Collections.Generic;
using System.Text;
using RoboRally.Core.Cards;
using RoboRally.Core.FactoryFloor;
using RoboRally.Core.Phases;

namespace RoboRally.Core
{
	public class Game : IGame
	{
		private readonly ICardDeck _cardDeck;

		public Game(ICardDeck cardDeck, IPlayer[] players)
		{
			_cardDeck = cardDeck;
			Players = players;
		}

		public IPlayer[] Players { get; private set; }

		public ICardDeck CardDeck { get; private set; }

		public IPhase CurrentPhase => throw new NotImplementedException();

		public IFactoryFloor FactoryFloor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

		public void FireLaser(IRobot robot)
		{
			throw new NotImplementedException();
		}

		public void Initialize()
		{
			_cardDeck.Shuffle();
		}

		public void KillRobot(IRobot robot)
		{
			throw new NotImplementedException();
		}

		public void MoveRobot(IRobot robot, Direction direction)
		{
			throw new NotImplementedException();
		}

		public void RotateRobot(IRobot robot, RotateDirection left)
		{
			throw new NotImplementedException();
		}
	}
}
