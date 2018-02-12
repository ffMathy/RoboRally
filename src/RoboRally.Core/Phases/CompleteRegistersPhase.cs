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

		public CompleteRegistersPhase(IGame game)
		{
			_game = game;
		}

		public void Commit()
		{
			for (var registerOffset = 0; registerOffset < 5; registerOffset++)
			{
				MoveRobots(registerOffset);
				MoveBoardElements(registerOffset);
				FireLasers();
				TouchFlags();
			}
		}

		private void MoveBoardElements(int registerOffset)
		{
			var prioritizedTiles = _game
				.FactoryFloor
				.Tiles
				.OrderByDescending(x => x.MovePriority);
			foreach (var tile in prioritizedTiles) {
				tile.Move(registerOffset);
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
			foreach(var player in _game.Players) {
				player.Robot.FireLaser();
			}
		}

		private void MoveRobots(int registerOffset)
		{
			var instructions = _game
				.Players
				.Select(player => (
					Card: player.ProgramSheet.RegisterCards[registerOffset], 
					Player: player))
				.OrderByDescending(player => player.Card.Priority);
			foreach(var instruction in instructions)
			{
				Debug.WriteLine("Player " + instruction.Player + " is playing card " + instruction.Card);
				instruction.Card.ExecuteOnBehalfOfPlayer(instruction.Player);
			}
		}
	}
}
