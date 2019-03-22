using System;

namespace RoboRally.Core.Phases
{
    [Serializable]
    class AnnouncePowerDownPhase : IAnnouncePowerDownPhase
	{
		public void SetPowerDownState(IPlayer player, bool willPowerDown)
		{
			player.ProgramSheet.IsPoweredDown = willPowerDown;
		}

        public bool Step()
        {
            return true;
        }
    }
}
