using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
	class Player : IPlayer
	{
		public IHand Hand { get; set; }

		public IProgramSheet ProgramSheet { get; set; }

		public IRobot Robot { get; set; }

		public Player(IGame game)
		{
			Hand = new Hand();
			ProgramSheet = new ProgramSheet();
			Robot = new Robot()
			{
				Game = game,
				Player = this
			};
		}
	}
}
