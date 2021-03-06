using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Entities.Attachments;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.Aggregates.DraftApplications.Events
{
    public class DraftApplicationAttachmentsDeleted : DomainEvent
    {
        public DraftApplicationAttachmentsDeleted(DraftApplicationId draftApplicationId, List<Attachment> deletedAttachments): base(draftApplicationId.Value.ToString())
        {
            this.DraftApplicationId = draftApplicationId;
            this.DeletedAttachments = deletedAttachments;
        }

        public DraftApplicationId DraftApplicationId { get; }
        public List<Attachment> DeletedAttachments { get; }
    }
}
