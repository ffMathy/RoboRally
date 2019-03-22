namespace RoboRally.Core
{
    class PlayerFactory : IPlayerFactory
	{
		public IPlayer Create(IGame game)
		{
			return new Player(game);
		}
	}
}
