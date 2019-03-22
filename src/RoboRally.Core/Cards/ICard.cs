namespace RoboRally.Core.Cards
{
    public interface ICard
	{
		IGame Game { get; set; }

		int Priority { get; set; }

        string ResourceName { get; }

		void ExecuteOnBehalfOfPlayer(IPlayer player);
	}
}
