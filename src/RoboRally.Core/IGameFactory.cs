namespace RoboRally.Core
{
    public interface IGameFactory
    {
		IGame Create(int playerCount);
    }
}
