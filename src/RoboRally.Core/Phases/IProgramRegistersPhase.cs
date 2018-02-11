using RoboRally.Core.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Phases
{
	public interface IProgramRegistersPhase : IPhase
	{
		void AddHandCardToProgramSheet(IPlayer player, ICard card);
		void RemoveCardFromProgramSheetToHand(IPlayer player, ICard card);
	}
}
