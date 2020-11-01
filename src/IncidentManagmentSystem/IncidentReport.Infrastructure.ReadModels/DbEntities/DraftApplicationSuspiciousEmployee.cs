using System;

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class DraftApplicationSuspiciousEmployee
    {
        public Guid Id { get; set; }
        public Guid DraftApplicationId { get; set; }
        public Guid? EmployeeId { get; set; }

        public virtual DraftApplication DraftApplication { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
