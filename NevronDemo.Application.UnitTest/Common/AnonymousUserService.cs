using NevronDemo.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NevronDemo.Application.UnitTest.Common
{
    public class AnonymousUserService : ICurrentUserService
    {
        public string UserId => "anonymous";

        public bool IsAuthenticated => false;
    }
}
