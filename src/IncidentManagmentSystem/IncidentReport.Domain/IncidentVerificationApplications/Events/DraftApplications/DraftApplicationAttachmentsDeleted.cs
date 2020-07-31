using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications
{
    public class DraftApplicationAttachmentsDeleted : DomainEvent
    {
        public DraftApplicationAttachmentsDeleted(DraftApplicationId draftApplicationId, List<Attachment> deletedAttachments)
        {
            this.DraftApplicationId = draftApplicationId;
            this.DeletedAttachments = deletedAttachments;
        }

        public DraftApplicationId DraftApplicationId { get; }
        public List<Attachment> DeletedAttachments { get; }
    }
}
