using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface IGameFactory
    {
		IGame Create(int playerCount);
    }
}
