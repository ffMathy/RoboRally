using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
	class PlayerFactory : IPlayerFactory
	{
		public IPlayer Create()
		{
			return new Player();
		}
	}
}
