using System;
using System.Collections.Generic;
using System.Text;

namespace NevronDemo.Domain.Common
{
    public abstract class AuditableEntity : EntityBase
    {
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
