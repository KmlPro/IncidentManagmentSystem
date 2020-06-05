using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class DraftApplicationSuspiciousEmployeeDeleted : DomainEvent
    {
        public DraftApplicationSuspiciousEmployeeDeleted(DraftApplicationId draftApplicationId, List<SuspiciousEmployee> suspiciousEmployee)
        {
            this.DraftApplicationId = draftApplicationId;
            this.SuspiciousEmployee = suspiciousEmployee;
        }

        public DraftApplicationId DraftApplicationId { get; }
        public List<SuspiciousEmployee> SuspiciousEmployee { get; }
    }
}
