namespace RoboRally.Core.Phases
{
	public interface IPhase
	{
		IGame Game { get; }
		void Commit();
	}
}