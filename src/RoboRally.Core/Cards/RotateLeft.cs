
namespace RoboRally.Core.Cards
{
    public class Rotate : ICard
    {
		public RotateDirection Direction { get; set; }
		public int Priority { get; set; }

		public int Count { get; set; }

		public IGame Game => throw new System.NotImplementedException();

		public void ExecuteOnBehalfOfPlayer(IPlayer player)
		{
			throw new System.NotImplementedException();
		}
	}
}
