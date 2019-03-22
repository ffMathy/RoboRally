using System;

namespace RoboRally.Core
{
    [Serializable]
    class PlayerFactory : IPlayerFactory
	{
		public IPlayer Create(IGame game)
		{
			return new Player(game);
		}
	}
}
