using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.DraftApplications
{
    public interface IDraftApplicationRepository
    {
        void Delete(DraftApplicationId draftApplicationId);
        Task<DraftApplication> GetById(DraftApplicationId applicationId, CancellationToken cancellationToken);
        Task Create(DraftApplication draftApplication, CancellationToken cancellationToken);
        void Update(DraftApplication draftApplication);
        Task<bool> IsExists(DraftApplicationId draftApplicationId, CancellationToken cancellationToken);
    }
}
