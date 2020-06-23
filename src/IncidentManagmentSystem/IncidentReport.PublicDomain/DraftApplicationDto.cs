using System;
using System.Collections.Generic;

namespace IncidentReport.PublicDomain
{
    public class DraftApplicationDto
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string IncidentType { get; }
        public List<Guid> SuspiciousEmployees { get; }
        public Guid ApplicantId { get; }
        public List<AttachmentsDto> Attachments { get; }

        public DraftApplicationDto(Guid id, string title, string description, string incidentType, List<Guid> suspiciousEmployees, Guid applicantId, List<AttachmentsDto> attachments)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.ApplicantId = applicantId;
            this.Attachments = attachments;
        }
    }
}
