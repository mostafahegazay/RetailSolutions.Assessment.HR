using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace RetailSolutions.Assessment.HR.Entities
{
    public class TimeLog : AuditedAggregateRoot<Guid>
    {
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public IdentityUser Creator { get; set; }
    }
}
