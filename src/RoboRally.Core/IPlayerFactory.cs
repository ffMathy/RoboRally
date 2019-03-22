namespace RoboRally.Core
{
    public interface IPlayerFactory
    {
		IPlayer Create(IGame game);
    }
}
