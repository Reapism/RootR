using System;
using System.Collections.Generic;
using System.Text;

namespace Rootr.Shared.Trigger
{
    interface ITriggerable<T>
        where T : class, ITrigger
    {
        void TriggerFor<T>(T value);
    }
}
