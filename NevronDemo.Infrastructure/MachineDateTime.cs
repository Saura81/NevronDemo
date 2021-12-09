using NevronDemo.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NevronDemo.Infrastructure
{
    internal class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

    }
}
