using System;
using System.Collections.Generic;

#nullable disable

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class DraftApplicationSuspiciousEmployee
    {
        public int Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid DraftApplicationId { get; set; }

        public virtual DraftApplication DraftApplication { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
