using RetailSolutions.Assessment.HR.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace RetailSolutions.Assessment.HR.Entities
{
    public class Shift : Entity<Guid>
    {
        public string Name { get; set; }
        public eShiftType ShiftType { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
    }
}
