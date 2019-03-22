namespace RoboRally.Core.Tiles
{
    public interface ITileRelation
    {
		ITile Tile { get; set; }
	
		bool IsObstructed { get; }
	}
}
