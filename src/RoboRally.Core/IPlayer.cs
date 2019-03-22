namespace RoboRally.Core
{
    public interface IPlayer
    {
		IHand Hand { get; }
		IProgramSheet ProgramSheet { get; }
		IRobot Robot { get; }

        string Label { get; }
    }
}
