using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Domain.Common
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
