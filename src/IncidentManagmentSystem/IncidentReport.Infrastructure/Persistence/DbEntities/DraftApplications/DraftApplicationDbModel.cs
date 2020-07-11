using System;
using System.Collections.Generic;
using IncidentReport.Infrastructure.Persistence.DbEntities.Attachments;
using IncidentReport.Infrastructure.Persistence.DbEntities.Employees;
using IncidentReport.Infrastructure.PublicDomain.Employees;

namespace IncidentReport.Infrastructure.Persistence.DbEntities.DraftApplications
{
    public class DraftApplicationDbModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IncidentType { get; set; }
        public ICollection<EmployeeDbModel> SuspiciousEmployees { get; set; }
        public EmployeeDto Applicant { get; set; }
        public ICollection<AttachmentDbModel> Attachments { get; set; }
    }
}
