using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface IPlayerFactory
    {
		IPlayer Create(IGame game);
    }
}
