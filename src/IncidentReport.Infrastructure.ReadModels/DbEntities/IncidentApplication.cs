using System;
using System.Collections.Generic;

#nullable disable

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class IncidentApplication
    {
        public IncidentApplication()
        {
            Attachments = new HashSet<Attachment>();
            IncidentApplicationSuspiciousEmployees = new HashSet<IncidentApplicationSuspiciousEmployee>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string IncidentType { get; set; }
        public Guid? ApplicantId { get; set; }
        public string ApplicationStateValue { get; set; }

        public virtual Employee Applicant { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<IncidentApplicationSuspiciousEmployee> IncidentApplicationSuspiciousEmployees { get; set; }
    }
}
