using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Entities.Attachments;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.Aggregates.DraftApplications.Events
{
    public class DraftApplicationAttachmentsAdded : DomainEvent
    {
        public DraftApplicationAttachmentsAdded(DraftApplicationId draftApplicationId, List<Attachment> addedAttachments): base(draftApplicationId.Value.ToString())
        {
            this.DraftApplicationId = draftApplicationId;
            this.AddedAttachments = addedAttachments;
        }

        public DraftApplicationId DraftApplicationId { get; }
        public List<Attachment> AddedAttachments { get; }
    }
}
