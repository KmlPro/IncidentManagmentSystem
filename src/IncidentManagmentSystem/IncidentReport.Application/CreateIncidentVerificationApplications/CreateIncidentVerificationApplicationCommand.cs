using System;
using System.Collections.Generic;
using BuildingBlocks.Application.Commands;
using IncidentReport.Application.Common;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;

namespace IncidentReport.Application.CreateIncidentVerificationApplications
{
    public class CreateIncidentVerificationApplicationCommand : CommandBase
    {
        public string Title { get; }
        public string Content { get; }
        public IncidentType IncidentType { get; }
        public IEnumerable<Guid> SuspiciousEmployees { get; }
        public List<FileData> Attachments { get; }
    }
}
