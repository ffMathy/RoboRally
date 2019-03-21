using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Phases
{
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
