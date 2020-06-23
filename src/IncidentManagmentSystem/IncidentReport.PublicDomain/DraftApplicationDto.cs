using System;
using System.Collections.Generic;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;

namespace IncidentReport.PublicDomain
{
    public class DraftApplicationDto
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public IncidentType? IncidentType { get; }
        public List<Guid> SuspiciousEmployees { get; }
        public Guid ApplicantId { get; }
        public List<AttachmentsDto> Attachments { get; }

        public DraftApplicationDto(Guid id, string title, string description, IncidentType? incidentType, List<Guid> suspiciousEmployees, Guid applicantId, List<AttachmentsDto> attachments)
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
