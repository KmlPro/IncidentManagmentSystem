using System;

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class IncidentApplicationSuspiciousEmployee
    {
        public Guid Id { get; set; }
        public Guid IncidentApplicationId { get; set; }
        public Guid? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual IncidentApplication IncidentApplication { get; set; }
    }
}
