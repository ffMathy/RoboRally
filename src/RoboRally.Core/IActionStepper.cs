using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRally.Core
{
    public interface IActionStepper
    {
        bool Step(params Action[] actionsToStepThrough);
    }
}
