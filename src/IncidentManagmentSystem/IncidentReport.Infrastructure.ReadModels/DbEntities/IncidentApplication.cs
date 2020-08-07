using System;
using System.Collections.Generic;

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class IncidentApplication
    {
        public IncidentApplication()
        {
            Attachment = new HashSet<Attachment>();
            IncidentApplicationSuspiciousEmployee = new HashSet<IncidentApplicationSuspiciousEmployee>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IncidentTypeValue { get; set; }
        public Guid? ApplicantId { get; set; }
        public string ApplicationStateValue { get; set; }

        public virtual Employee Applicant { get; set; }
        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual ICollection<IncidentApplicationSuspiciousEmployee> IncidentApplicationSuspiciousEmployee { get; set; }
    }
}
