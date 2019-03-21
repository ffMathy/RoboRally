using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
	class Player : IPlayer
	{
		private int _id;

		private static int Id;

		public IHand Hand { get; set; }
		public IProgramSheet ProgramSheet { get; set; }
		public IRobot Robot { get; set; }

        public string Label => ToString();

        public Player(IGame game)
		{
			_id = ++Id;

			Hand = new Hand();
			ProgramSheet = new ProgramSheet();
			Robot = new Robot()
			{
				Game = game,
				Player = this
			};
		}

		public override string ToString()
		{
			return "P" + _id;
		}
	}
}
