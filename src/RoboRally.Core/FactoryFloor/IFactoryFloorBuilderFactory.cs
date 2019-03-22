namespace RoboRally.Core.FactoryFloor
{
    public interface IFactoryFloorBuilderFactory
    {
		IFactoryFloorBuilder Create(int width, int height);
    }
}
