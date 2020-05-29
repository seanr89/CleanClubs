using System;

namespace Clubs.Domain.Common
{
    public abstract class AuditableEntity
    {
        public string CreatedBy { get; set; } = "Uknown";

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}