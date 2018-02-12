using System;
using System.Collections.Generic;
using System.Text;
using RoboRally.Core.Cards;
using RoboRally.Core.FactoryFloor;
using RoboRally.Core.Phases;
using RoboRally.Core.Tiles;

namespace RoboRally.Core
{
	public class Game : IGame
	{
		private readonly ICardDeck _cardDeck;

		public event Action RenderRequested;

		public Game(ICardDeck cardDeck, IPlayer[] players)
		{
			_cardDeck = cardDeck;
			Players = players;
		}

		public IPlayer[] Players { get; private set; }

		public ICardDeck CardDeck { get; private set; }

		public IPhase CurrentPhase { get; private set; }

		public IFactoryFloor FactoryFloor { get; set; }

		public IAnnouncePowerDownPhase EnterAnnouncePowerDownPhase()
		{
			return EnterPhase(() => new AnnouncePowerDownPhase());
		}

		public ICleanupPhase EnterCleanupPhase()
		{
			return EnterPhase(() => new CleanupPhase());
		}

		public ICompleteRegistersPhase EnterCompleteRegistersPhase()
		{
			return EnterPhase(() => new CompleteRegistersPhase(this));
		}

		public IDealProgramCardsPhase EnterDealProgramCardsPhase()
		{
			return EnterPhase(() => new DealProgramCardsPhase(game));
		}

		public IProgramRegistersPhase EnterProgramRegistersPhase()
		{
			return EnterPhase(() => new ProgramRegistersPhase());
		}

		private TPhase EnterPhase<TPhase>(Func<TPhase> phaseConstructor) where TPhase : IPhase {
			var phase = phaseConstructor();
			CurrentPhase = phase;

			return phase;
		}

		public void FireLaser(IRobot robot)
		{
			ITile nextTile = robot.CurrentTile;

			do {
				var relation = GetTileRelationInDirectionOfTile(nextTile, robot.Direction);
				if(relation.IsObstructed)
					return;

				nextTile = relation.Tile;

				var nextTileRobot = nextTile.Robot;
				if(nextTileRobot != null)
					DamageRobot(nextTileRobot, 1);
					
			} while(nextTile != null);

			FireRenderRequested();
		}

		public void Initialize()
		{
			_cardDeck.Shuffle();
		}

		private void DamageRobot(IRobot robot, int damageTokenCount) {
			var newDamageTokenCount = robot.Player.ProgramSheet.DamageTokenCount += damageTokenCount;
			throw new NotImplementedException("Death of robots has not been implemented yet.");
		}

		public void KillRobot(IRobot robot)
		{
			DamageRobot(robot, 9 - robot.Player.ProgramSheet.DamageTokenCount);
			FireRenderRequested();
		}

		public ITile MoveRobot(IRobot robot, OrientationDirection direction)
		{
			var currentTile = robot.CurrentTile;
			var relation = GetTileRelationInDirectionOfTile(currentTile, direction);
			var newTile = relation.Tile;

			if(relation.IsObstructed)
				return null;

			var existingRobot = newTile.Robot;
			if(existingRobot != null) { 
				var newTileForExistingRobot = MoveRobot(existingRobot, direction);
				if (newTileForExistingRobot == null)
					return null;
			}

			newTile.Robot = robot;
			robot.CurrentTile = newTile;

			FireRenderRequested();

			return newTile;
		}

		public void RotateRobot(IRobot robot, RotateDirection rotateDirection)
		{
			robot.Direction = DirectionHelper.GetRotatedDirection(robot.Direction, rotateDirection);
			FireRenderRequested();
		}

		private void FireRenderRequested() {
			RenderRequested?.Invoke();
		}

		private ITileRelation GetTileRelationInDirectionOfTile(ITile tile, OrientationDirection direction) {
			switch(direction) {
				case OrientationDirection.Down:
					return tile.Bottom;

				case OrientationDirection.Up:
					return tile.Top;

				case OrientationDirection.Left:
					return tile.Left;

				case OrientationDirection.Right:
					return tile.Right;

				default:
					throw new InvalidOperationException("An unknown direction " + direction + " was specified.");
			}
		}
	}
}
