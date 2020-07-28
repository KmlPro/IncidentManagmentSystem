using System;
using System.Collections.Generic;

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class Employee
    {
        public Employee()
        {
            DraftApplication = new HashSet<DraftApplication>();
            SuspiciousEmployee = new HashSet<SuspiciousEmployee>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<DraftApplication> DraftApplication { get; set; }
        public virtual ICollection<SuspiciousEmployee> SuspiciousEmployee { get; set; }
    }
}
