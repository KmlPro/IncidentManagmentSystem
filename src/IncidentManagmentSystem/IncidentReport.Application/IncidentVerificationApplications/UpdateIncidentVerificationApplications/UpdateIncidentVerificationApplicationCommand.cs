using System;
using System.Collections.Generic;
using BuildingBlocks.Application.Commands;
using IncidentReport.Application.Common.File;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;

namespace IncidentReport.Application.IncidentVerificationApplications.UpdateIncidentVerificationApplications
{
    public class UpdateIncidentVerificationApplicationCommand : CommandBase
    {
        public Guid DraftIncidentVerificationApplicationId { get; set; }
        public string Title { get; }
        public string Content { get; }
        public IncidentType IncidentType { get; }
        public IEnumerable<Guid> SuspiciousEmployees { get; }
        public List<FileData> AddedAttachments { get; }
        public List<Guid> DeletedAttachments { get; }
    }
}
