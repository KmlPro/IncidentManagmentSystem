using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class DraftApplicationAttachmentsAdded : DomainEvent
    {
        public DraftApplicationAttachmentsAdded(DraftApplicationId draftApplicationId, List<Attachment> attachments)
        {
            this.DraftApplicationId = draftApplicationId;
            this.Attachments = attachments;
        }

        public DraftApplicationId DraftApplicationId { get; }
        public List<Attachment> Attachments { get; }
    }
}
