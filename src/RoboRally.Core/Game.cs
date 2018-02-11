﻿using System;
using System.Collections.Generic;
using System.Text;
using RoboRally.Core.Cards;
using RoboRally.Core.FactoryFloor;
using RoboRally.Core.Phases;

namespace RoboRally.Core
{
	public class Game : IGame
	{
		private readonly ICardDeckFactory _cardDeckFactory;

		public Game(ICardDeckFactory cardDeckFactory)
		{
			_cardDeckFactory = cardDeckFactory;
		}

		public IPlayer[] Players => throw new NotImplementedException();

		public ICardDeck CardDeck { get; set; }

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
			var deck = _cardDeckFactory.CreateDeck();

			deck.Shuffle();

			CardDeck = deck;
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
