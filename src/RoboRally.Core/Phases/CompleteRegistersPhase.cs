using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace RoboRally.Core.Phases
{
	class CompleteRegistersPhase : ICompleteRegistersPhase
	{
		private readonly IGame _game;
        private readonly IActionStepper _actionStepper;

        private int _registerOffset;

        public CompleteRegistersPhase(
            IGame game,
            IActionStepper actionStepper)
		{
			_game = game;
            _actionStepper = actionStepper;
        }

		private void MoveBoardElements()
		{
			var prioritizedTiles = _game
				.FactoryFloor
				.Tiles
				.OrderByDescending(x => x.MovePriority)
				.Where(x => x.Robot != null);
			foreach (var tile in prioritizedTiles)
			{
				if (tile.Robot.LastMovedRegisterOffset == _registerOffset)
					continue;

				tile.Robot.LastMovedRegisterOffset = _registerOffset;
				tile.Move(_registerOffset);
			}
		}

		private void TouchFlags()
		{
			foreach (var player in _game.Players)
			{
				foreach (var tile in _game.FactoryFloor.Tiles)
				{
					tile.TouchByRobot(player.Robot);
				}
			}
		}

		private void FireLasers()
		{
			foreach (var player in _game.Players)
			{
				player.Robot.FireLaser();
			}
		}

		private void MoveRobots()
		{
			var instructions = _game
				.Players
				.Select(player => (
					Card: player.ProgramSheet.RegisterCards[_registerOffset],
					Player: player))
				.OrderByDescending(player => player.Card.Priority);

			foreach (var instruction in instructions)
			{
				Debug.WriteLine("Player " + instruction.Player + " is playing card " + instruction.Card);
				instruction.Card.ExecuteOnBehalfOfPlayer(instruction.Player);
			}
		}

        public bool Step()
        {
            var hasFinished = _actionStepper.Step(
                MoveRobots,
                MoveBoardElements,
                FireLasers,
                TouchFlags);
            if (hasFinished)
                _registerOffset++;

            if (_registerOffset == 5)
                return true;

            return false;
        }
    }
}
