using System.Threading;
using System.Threading.Tasks;

namespace InitialIncidentVerification.Domain.Aggregates
{
    public interface IIncidentApplicationRepository
    {
        Task Create(IncidentApplication incidentApplication, CancellationToken cancellationToken);
    }
}
