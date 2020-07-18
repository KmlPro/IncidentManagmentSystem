using System;
using System.Collections.Generic;

namespace IncidentReport.ReadModels.Models
{
    public partial class SuspiciousEmployee
    {
        public Guid Id { get; set; }
        public Guid DraftApplicationId { get; set; }
        public Guid? EmployeeId { get; set; }

        public virtual DraftApplication DraftApplication { get; set; }
    }
}
