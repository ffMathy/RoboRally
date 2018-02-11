
namespace RoboRally.Core.Cards
{
    public class Rotate : ICard
    {
		public RotateDirection Direction { get; set; }
		public int Priority { get; set; }

		public int Count { get; set; }
	}
}
