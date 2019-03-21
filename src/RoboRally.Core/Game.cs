using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using RoboRally.Core.Cards;
using RoboRally.Core.FactoryFloor;
using RoboRally.Core.Phases;
using RoboRally.Core.Tiles;

namespace RoboRally.Core
{
	class Game : IGame
	{
		private const int RobotDamageCapacity = 10;

        private readonly IActionStepper _actionStepper;

        public event Action RenderRequested;

		public Game(
            ICardDeckFactory cardDeckFactory, 
            IPlayerFactory playerFactory, 
            IActionStepper actionStepper,
            int playerCount)
		{
			CardDeck = cardDeckFactory.CreateDeck(this);

			var players = new List<IPlayer>();
			for (var i = 0; i < playerCount; i++)
				players.Add(playerFactory.Create(this));

			Players = players.ToArray();

            _actionStepper = actionStepper;

            EnterDealProgramCardsPhase();
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
			return EnterPhase(() => new CleanupPhase(this, new ActionStepper()));
		}

		public ICompleteRegistersPhase EnterCompleteRegistersPhase()
		{
			return EnterPhase(() => new CompleteRegistersPhase(this, new ActionStepper()));
		}

		public IDealProgramCardsPhase EnterDealProgramCardsPhase()
		{
			return EnterPhase(() => new DealProgramCardsPhase(this, new ActionStepper()));
		}

		public IProgramRegistersPhase EnterProgramRegistersPhase()
		{
			return EnterPhase(() => new ProgramRegistersPhase());
		}

		private TPhase EnterPhase<TPhase>(Func<TPhase> phaseConstructor) where TPhase : IPhase
		{
			var phase = phaseConstructor();
			CurrentPhase = phase;

			Debug.WriteLine("Entering phase: " + phase.GetType().Name);

			return phase;
		}

		public void FireLaser(
            IRobot robot)
		{
			Debug.WriteLine("Firing laser for robot " + robot);

			ITile currentTile = robot.CurrentTile;

			while(true)
			{
				var relation = GetTileRelationInDirectionOfTile(currentTile, robot.Direction);
				if (relation.IsObstructed)
					break;

				if (relation.Tile == null)
					break;

				var nextTile = relation.Tile;

				var nextTileRobot = nextTile.Robot;
				if (nextTileRobot != null)
					DamageRobot(nextTileRobot, 1);

				currentTile = nextTile;
			}

			FireRenderRequested();
		}

		public void Initialize()
		{
			CardDeck.Shuffle();
		}

		private void DamageRobot(
            IRobot robot, 
            int damageTakenCount)
		{
            try
            {
                var newDamageTokenCount = robot.Player.ProgramSheet.DamageTokenCount += damageTakenCount;
                Debug.WriteLine("Damaging robot " + robot + " by " + damageTakenCount + " - now has " + robot.Player.ProgramSheet.DamageTokenCount + " damage tokens");

                if (newDamageTokenCount < RobotDamageCapacity)
                    return;

                var newLifeTokenCount = robot.Player.ProgramSheet.LifeTokenCount--;
                robot.Player.ProgramSheet.DamageTokenCount = 2;

                if (newLifeTokenCount > 0)
                    return;

                var currentRobotTile = robot.CurrentTile;
                currentRobotTile.Robot = null;
                robot.CurrentTile = null;
            } finally
            {
                FireRenderRequested();
            }
		}

		public void KillRobot(
            IRobot robot)
		{
			DamageRobot(robot, RobotDamageCapacity - robot.Player.ProgramSheet.DamageTokenCount);
			FireRenderRequested();
		}

		public ITile MoveRobot(
            IRobot robot, 
            OrientationDirection direction)
		{
			Debug.WriteLine("Moving robot " + robot + " " + direction);

			var currentTile = robot.CurrentTile;
			var relation = GetTileRelationInDirectionOfTile(currentTile, direction);
			var newTile = relation.Tile;

			if (relation.IsObstructed)
				return null;

			var existingRobot = newTile.Robot;
			if (existingRobot != null)
			{
				var newTileForExistingRobot = MoveRobot(existingRobot, direction);
				if (newTileForExistingRobot == null)
					return null;
			}

			currentTile.Robot = null;
			newTile.Robot = robot;
			robot.CurrentTile = newTile;

			FireRenderRequested();

			return newTile;
		}

		public void RotateRobot(
            IRobot robot, 
            RotateDirection rotateDirection)
		{
			Debug.WriteLine("Rotating robot " + robot + " " + rotateDirection);

			robot.Direction = DirectionHelper.GetRotatedDirection(robot.Direction, rotateDirection);
			FireRenderRequested();
		}

		private void FireRenderRequested()
		{
			RenderRequested?.Invoke();
		}

		private ITileRelation GetTileRelationInDirectionOfTile(
            ITile tile, 
            OrientationDirection direction)
		{
			switch (direction)
			{
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

        public void Step()
        {
            var isPhaseFinished = CurrentPhase.Step();

            FireRenderRequested();

            if (isPhaseFinished)
            {
                _actionStepper.Step(
                    () => EnterDealProgramCardsPhase(),
                    () => EnterProgramRegistersPhase(),
                    () => EnterAnnouncePowerDownPhase(),
                    () => EnterCompleteRegistersPhase(),
                    () => EnterCleanupPhase());
            }
        }
    }
}
