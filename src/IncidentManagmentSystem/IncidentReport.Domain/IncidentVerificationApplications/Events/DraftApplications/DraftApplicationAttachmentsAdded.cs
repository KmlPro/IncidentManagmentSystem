using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications
{
    public class DraftApplicationAttachmentsAdded : DomainEvent
    {
        public DraftApplicationAttachmentsAdded(DraftApplicationId draftApplicationId, List<Attachment> addedAttachments)
        {
            this.DraftApplicationId = draftApplicationId;
            this.AddedAttachments = addedAttachments;
        }

        public DraftApplicationId DraftApplicationId { get; }
        public List<Attachment> AddedAttachments { get; }
    }
}
