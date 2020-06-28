using System;
using System.Collections.Generic;
using IncidentReport.Infrastructure.PublicDomain.Attachments;
using IncidentReport.Infrastructure.PublicDomain.Employees;

namespace IncidentReport.Infrastructure.PublicDomain.DraftApplications
{
    public class DraftApplicationDto : IDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IncidentType { get; set; }
        public IEnumerable<EmployeeDto> SuspiciousEmployees { get; set; }
        public EmployeeDto Applicant { get; set; }
        public IEnumerable<AttachmentDto> Attachments { get; set; }
    }
}
