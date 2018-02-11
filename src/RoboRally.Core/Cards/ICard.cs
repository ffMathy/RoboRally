﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
	public interface ICard
	{
		IGame Game { get; }

		int Priority { get; }

		void ExecuteOnBehalfOfPlayer(IPlayer player);
	}
}
