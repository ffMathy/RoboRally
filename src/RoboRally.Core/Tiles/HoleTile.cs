﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RoboRally.Core.Tiles
{
	public class HoleTile : TileBase
	{
		public override string ResourceName => $"Hole";

		public override void Move(int registerOffset)
		{
			if (Robot == null)
				return;

			Debug.WriteLine(this + " move");
			Game.KillRobot(Robot);
		}
		
		public override string ToString()
		{
			return "[Hole]";
		}
	}
}
