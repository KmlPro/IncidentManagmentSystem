using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class DraftApplicationAttachmentsDeleted : DomainEvent
    {
        public DraftApplicationId DraftApplicationId { get; }
        public List<Attachment> Attachments { get; }

        public DraftApplicationAttachmentsDeleted(DraftApplicationId draftApplicationId, List<Attachment> attachments)
        {
            this.DraftApplicationId = draftApplicationId;
            this.Attachments = attachments;
        }
    }
}
