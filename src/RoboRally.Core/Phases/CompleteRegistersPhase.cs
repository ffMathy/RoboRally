﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboRally.Core.Phases
{
	class CompleteRegistersPhase : ICompleteRegistersPhase
	{
		private readonly IGame game;

		public CompleteRegistersPhase(IGame game)
		{
			this.game = game;
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
			var prioritizedTiles = game
				.FactoryFloor
				.Tiles
				.OrderByDescending(x => x.MovePriority);
			foreach (var tile in prioritizedTiles) {
				tile.BeforeMove(registerOffset);
			}
		}

		private void TouchFlags()
		{
			foreach (var player in game.Players)
			{
				foreach (var tile in game.FactoryFloor.Tiles)
				{
					tile.TouchByRobot(player.Robot);
				}
			}
		}

		private void FireLasers()
		{
			foreach(var player in game.Players) {
				player.Robot.FireLaser();
			}
		}

		private void MoveRobots(int registerOffset)
		{
			var instructions = game
				.Players
				.Select(player => (
					Card: player.ProgramSheet.RegisterCards[registerOffset], 
					Player: player))
				.OrderByDescending(player => player.Card.Priority);
			foreach(var instruction in instructions)
			{
				instruction.Card.ExecuteOnBehalfOfPlayer(instruction.Player);
			}
		}
	}
}
