using System;
using System.Collections.Generic;
using BuildingBlocks.Application.UseCases;
using IncidentReport.Application.Files;

namespace IncidentReport.Application.Boundaries.UpdateDraftApplications
{
    public class UpdateDraftApplicationInput : IUseCaseInput<IOutputPort>
    {
        public UpdateDraftApplicationInput(Guid draftApplicationId,
            string title,
            string content,
            string incidentType,
            IEnumerable<Guid> suspiciousEmployees,
            List<FileData> addedAttachments,
            List<Guid> deletedAttachments)
        {
            this.DraftApplicationId = draftApplicationId;
            this.Title = title;
            this.Content = content;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.AddedAttachments = addedAttachments;
            this.DeletedAttachments = deletedAttachments;
        }

        public Guid DraftApplicationId { get; set; }
        public string Title { get; }
        public string Content { get; }
        public string IncidentType { get; }
        public IEnumerable<Guid> SuspiciousEmployees { get; }
        public List<FileData> AddedAttachments { get; }
        public List<Guid> DeletedAttachments { get; }
    }
}
