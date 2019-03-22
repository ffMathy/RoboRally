using RoboRally.Core.Cards;

namespace RoboRally.Core.Phases
{
    public interface IProgramRegistersPhase : IPhase
	{
		void AddHandCardToProgramSheet(IPlayer player, ICard card);
		void RemoveCardFromProgramSheetToHand(IPlayer player, ICard card);
        bool DoesProgramSheetContainCard(IPlayer player, ICard card);
    }
}
