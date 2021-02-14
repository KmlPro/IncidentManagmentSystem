using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.ValueObjects
{
    public class AttachmentId : TypedIdValue
    {
        public AttachmentId(Guid value) : base(value)
        {
        }
    }
}
