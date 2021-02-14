using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.ValueObjects;

namespace IncidentReport.Domain.Aggregates.IncidentApplications
{
    public interface IIncidentApplicationRepository
    {
        Task<IncidentApplication> GetPostedById(IncidentApplicationId incidentApplicationId,CancellationToken cancellationToken);
        Task Create(IncidentApplication incidentApplication, CancellationToken cancellationToken);
        Task<bool> IsExists(IncidentApplicationId draftApplicationId, CancellationToken cancellationToken);
    }
}
