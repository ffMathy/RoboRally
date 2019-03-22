using System;

namespace RoboRally.Core
{
    class ActionStepper : IActionStepper
    {
        private int _offset;

        public ActionStepper()
        {
            _offset = 0;
        }

        public bool Step(params Action[] actionsToStepThrough)
        {
            actionsToStepThrough[_offset++]();

            var completed = _offset == actionsToStepThrough.Length;
            if (completed)
                _offset = 0;

            return completed;
        }
    }
}
