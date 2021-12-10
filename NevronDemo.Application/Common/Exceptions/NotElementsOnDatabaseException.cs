using System;
using System.Collections.Generic;
using System.Text;

namespace NevronDemo.Application.Common.Exceptions
{
    public class NotElementsOnDatabaseException : Exception
    {
        public NotElementsOnDatabaseException(string name): base($"No elements on \"{name}\" entity ")
        {
        }

    }
}
