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
				MoveBoardElements();
				FireLasers();
				TouchFlags();
			}
		}

		private void MoveBoardElements()
		{
			throw new NotImplementedException();
		}

		private void TouchFlags()
		{
			throw new NotImplementedException();
		}

		private void FireLasers()
		{
			throw new NotImplementedException();
		}

		private void MoveRobots(int registerOffset)
		{
			var instructions = game
				.Players
				.Select(player => (
					Card: player.ProgramSheet.RegisterCards[registerOffset], 
					Player: player))
				.OrderByDescending(player => player.Card.Priority);
			foreach(var instruction in instructions) {
				game.ExecuteCard(
					instruction.Player, 
					instruction.Card);
			}
		}
	}
}
