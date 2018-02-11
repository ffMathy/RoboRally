using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Cards
{
    public class Uturn : ICard
    {
		public int Priority { get; set; }

		public IGame Game => throw new NotImplementedException();

		public void ExecuteOnBehalfOfPlayer(IPlayer player)
		{
			throw new NotImplementedException();
		}
	}
}
