using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class AttachmentId : TypedIdValueBase
    {
        public AttachmentId(Guid value) : base(value)
        {
        }
    }
}
