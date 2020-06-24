using System;
using System.Collections.Generic;

namespace IncidentReport.PublicDomain.DraftApplications
{
    public class DraftApplicationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IncidentType { get; set; }
        public List<Guid> SuspiciousEmployees { get; set; }
        public Guid ApplicantId { get; set; }
        public List<AttachmentDto> Attachments { get; set; }
    }
}
