using RoboRally.Core.Tiles;

namespace RoboRally.Core
{
    public interface IRobot
    {
		IGame Game { get; }
		IPlayer Player { get; }
		OrientationDirection Direction { get; set; }
		ITile CurrentTile { get; set; }
		ITile ArchiveMarkerPosition { get; }

		ITile[] FlagsTouched { get; }

		int LastMovedRegisterOffset { get; set; }

		void FireLaser();
	}
}
