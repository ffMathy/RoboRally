using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface IPlayer
    {
		IHand Hand { get; }
		IProgramSheet ProgramSheet { get; }
		IRobot Robot { get; }

        string Label { get; }
    }
}
