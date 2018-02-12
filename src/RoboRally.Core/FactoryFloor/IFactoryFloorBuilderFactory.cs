using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core.FactoryFloor
{
    public interface IFactoryFloorBuilderFactory
    {
		IFactoryFloorBuilder Create(int width, int height);
    }
}
