using System;
using System.Collections.Generic;
using IncidentReport.ReadModels.Dtos.Attachments;
using IncidentReport.ReadModels.Dtos.Employees;

namespace IncidentReport.ReadModels.Dtos.DraftApplications
{
    public class DraftApplicationDto
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
