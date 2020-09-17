using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications
{
    public class DraftApplicationSuspiciousEmployeeDeleted : DomainEvent
    {
        public DraftApplicationSuspiciousEmployeeDeleted(DraftApplicationId draftApplicationId, List<SuspiciousEmployee> suspiciousEmployee): base(draftApplicationId.Value.ToString())
        {
            this.DraftApplicationId = draftApplicationId;
            this.SuspiciousEmployee = suspiciousEmployee;
        }

        public DraftApplicationId DraftApplicationId { get; }
        public List<SuspiciousEmployee> SuspiciousEmployee { get; }
    }
}
