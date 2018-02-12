using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Cards
{
	public interface ICard
	{
		IGame Game { get; set; }

		int Priority { get; set; }

		void ExecuteOnBehalfOfPlayer(IPlayer player);
	}
}
