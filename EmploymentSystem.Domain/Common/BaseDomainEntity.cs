using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public Guid? LastModifiedBy { get; set; }
    }
}
