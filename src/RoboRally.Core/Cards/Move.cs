using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Cards
{
	public class Move : ICard
	{
		public MoveDirection MoveDirection { get; set; }
		public int Priority { get; set; }
		public int Count { get; set; }
	}
}
