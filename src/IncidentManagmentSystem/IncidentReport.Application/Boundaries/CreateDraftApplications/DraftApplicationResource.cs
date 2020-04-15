using System.Collections.Generic;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.Boundaries.CreateDraftApplications
{
    public class DraftApplicationResource
    {
        public DraftApplicationId Id { get; }
        public string Title { get; }
        public string Description { get; }
        public IncidentType? IncidentType { get; }
        public SuspiciousEmployees SuspiciousEmployees { get; }
        public EmployeeId ApplicantId { get; }
        public List<Attachment> Attachments { get; }

        public DraftApplicationResource(DraftApplicationId id, string title, string description, IncidentType? incidentType, SuspiciousEmployees suspiciousEmployees, EmployeeId applicantId, List<Attachment> attachments)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.ApplicantId = applicantId;
            this.Attachments = attachments;
        }

        //<summary>
        //kbytner 08.04.2020 - temporarty ctor, remove after testing
        //</summary>
        public DraftApplicationResource()
        {

        }
    }
}
