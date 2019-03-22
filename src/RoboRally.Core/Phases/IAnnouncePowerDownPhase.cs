namespace RoboRally.Core.Phases
{
    public interface IAnnouncePowerDownPhase: IPhase
    {
		void SetPowerDownState(IPlayer player, bool willPowerDown);
    }
}
