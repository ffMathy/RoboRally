using System;

namespace RoboRally.Core
{
    public interface IActionStepper
    {
        bool Step(params Action[] actionsToStepThrough);
    }
}
