using System;
using System.Collections.Generic;
using BuildingBlocks.Application.UseCases;
using IncidentReport.Application.Files;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;

namespace IncidentReport.Application.Boundaries.UpdateDraftApplications
{
    public class UpdateDraftApplicationInput : IUseCaseInput<IOutputPort>
    {
        public UpdateDraftApplicationInput(Guid draftApplicationId,
            string title,
            string description,
            IncidentType? incidentType,
            IEnumerable<Guid> suspiciousEmployees,
            List<FileData> addedAttachments,
            List<Guid> deletedAttachments)
        {
            this.DraftApplicationId = draftApplicationId;
            this.Title = title;
            this.Description = description;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.AddedAttachments = addedAttachments;
            this.DeletedAttachments = deletedAttachments;
        }

        public Guid DraftApplicationId { get; set; }
        public string Title { get; }
        public string Description { get; }
        public IncidentType? IncidentType { get; }
        public IEnumerable<Guid> SuspiciousEmployees { get; }
        public List<FileData> AddedAttachments { get; }
        public List<Guid> DeletedAttachments { get; }
    }
}
