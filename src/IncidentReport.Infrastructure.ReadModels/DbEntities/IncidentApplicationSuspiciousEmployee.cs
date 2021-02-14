using System;

#nullable disable

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class IncidentApplicationSuspiciousEmployee
    {
        public int Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid IncidentApplicationId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual IncidentApplication IncidentApplication { get; set; }
    }
}
