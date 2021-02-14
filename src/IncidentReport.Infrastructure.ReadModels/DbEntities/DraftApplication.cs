using System;
using System.Collections.Generic;

#nullable disable

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class DraftApplication
    {
        public DraftApplication()
        {
            Attachments = new HashSet<Attachment>();
            DraftApplicationSuspiciousEmployees = new HashSet<DraftApplicationSuspiciousEmployee>();
        }

        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string IncidentType { get; set; }
        public Guid? ApplicantId { get; set; }

        public virtual Employee Applicant { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<DraftApplicationSuspiciousEmployee> DraftApplicationSuspiciousEmployees { get; set; }
    }
}
