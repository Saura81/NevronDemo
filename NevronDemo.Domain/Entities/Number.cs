using NevronDemo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NevronDemo.Domain.Entities
{
    public class Number : AuditableEntity
    {
        public int Id { get; set; }

        public long Value { get; set; }
    }
}
