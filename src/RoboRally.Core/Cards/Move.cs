using System;

namespace RoboRally.Core.Cards
{
    public class Move : ICard
	{
		public MoveDirection Direction { get; set; }

		public int Priority { get; set; }
		public int Count { get; set; }

		public IGame Game { get; set; }

        public string ResourceName
        {
            get
            {
                if(Direction == MoveDirection.Forward)
                {
                    if (Count == 1)
                        return "move1";

                    if (Count == 2)
                        return "move2";

                    if (Count == 3)
                        return "move3";

                    throw new InvalidOperationException("Unknown forward count.");
                } else if(Direction == MoveDirection.Backward)
                {
                    if (Count == 1)
                        return "backup";

                    throw new InvalidOperationException("Unknown backward count.");
                }

                throw new InvalidOperationException("Unknown direction.");
            }
        }

        public void ExecuteOnBehalfOfPlayer(IPlayer player)
		{
			for (var i = 0; i < Count; i++)
				Game.MoveRobot(player.Robot, player.Robot.Direction);
		}

		public override string ToString()
		{
			return "[Move " + Direction + " " + Count + "]";
		}
	}
}
