using NevronDemo.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NevronDemo.Application.UnitTest.Common
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
