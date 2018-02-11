using System;
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
				.OrderByDescending(x => x.ActPriority);
			foreach (var tile in prioritizedTiles) {
				tile.Act(registerOffset);
			}
		}

		private void TouchFlags()
		{
		}

		private void FireLasers()
		{
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
