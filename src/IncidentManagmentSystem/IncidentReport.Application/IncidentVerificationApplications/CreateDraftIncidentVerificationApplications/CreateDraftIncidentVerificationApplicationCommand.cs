using System;
using System.Collections.Generic;
using BuildingBlocks.Application.Commands;
using IncidentReport.Application.Files;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;

namespace IncidentReport.Application.IncidentVerificationApplications.CreateDraftIncidentVerificationApplications
{
    public class CreateDraftIncidentVerificationApplicationCommand : CommandBase
    {
        public string Title { get; }
        public string Description { get; }
        public IncidentType IncidentType { get; }
        public IEnumerable<Guid> SuspiciousEmployees { get; }
        public List<FileData> Attachments { get; }

        public CreateDraftIncidentVerificationApplicationCommand(string title, string description, IncidentType incidentType, IEnumerable<Guid> suspiciousEmployees, List<FileData> attachments)
        {
            this.Title = title;
            this.Description = description;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.Attachments = attachments;
        }
    }
}
