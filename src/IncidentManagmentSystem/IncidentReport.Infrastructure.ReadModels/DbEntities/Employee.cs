using System;
using System.Collections.Generic;

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class Employee
    {
        public Employee()
        {
            DraftApplication = new HashSet<DraftApplication>();
            DraftApplicationAuditLog = new HashSet<DraftApplicationAuditLog>();
            DraftApplicationSuspiciousEmployee = new HashSet<DraftApplicationSuspiciousEmployee>();
            IncidentApplication = new HashSet<IncidentApplication>();
            IncidentApplicationSuspiciousEmployee = new HashSet<IncidentApplicationSuspiciousEmployee>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<DraftApplication> DraftApplication { get; set; }
        public virtual ICollection<DraftApplicationAuditLog> DraftApplicationAuditLog { get; set; }
        public virtual ICollection<DraftApplicationSuspiciousEmployee> DraftApplicationSuspiciousEmployee { get; set; }
        public virtual ICollection<IncidentApplication> IncidentApplication { get; set; }
        public virtual ICollection<IncidentApplicationSuspiciousEmployee> IncidentApplicationSuspiciousEmployee { get; set; }
    }
}
