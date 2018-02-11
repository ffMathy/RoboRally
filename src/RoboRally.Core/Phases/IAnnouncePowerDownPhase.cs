using RoboRally.Core.Phases;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.Phases
{
    public interface IAnnouncePowerDownPhase: IPhase
    {
		void SetPowerDownState(IPlayer player, bool willPowerDown);
    }
}
