using System;
using System.Collections.Generic;

#nullable disable

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class Employee
    {
        public Employee()
        {
            DraftApplicationAuditLogs = new HashSet<DraftApplicationAuditLog>();
            DraftApplicationSuspiciousEmployees = new HashSet<DraftApplicationSuspiciousEmployee>();
            DraftApplications = new HashSet<DraftApplication>();
            IncidentApplicationSuspiciousEmployees = new HashSet<IncidentApplicationSuspiciousEmployee>();
            IncidentApplications = new HashSet<IncidentApplication>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<DraftApplicationAuditLog> DraftApplicationAuditLogs { get; set; }
        public virtual ICollection<DraftApplicationSuspiciousEmployee> DraftApplicationSuspiciousEmployees { get; set; }
        public virtual ICollection<DraftApplication> DraftApplications { get; set; }
        public virtual ICollection<IncidentApplicationSuspiciousEmployee> IncidentApplicationSuspiciousEmployees { get; set; }
        public virtual ICollection<IncidentApplication> IncidentApplications { get; set; }
    }
}
