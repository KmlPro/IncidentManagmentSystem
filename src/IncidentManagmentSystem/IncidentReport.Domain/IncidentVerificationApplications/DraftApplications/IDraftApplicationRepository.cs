using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.DraftApplications
{
    public interface IDraftApplicationRepository
    {
        Task<DraftApplication> GetById(DraftApplicationId id, CancellationToken cancellationToken);
        void Update(DraftApplication draftApplication);
        Task Add(DraftApplication draftApplication, CancellationToken cancellationToken);
        void Delete(DraftApplicationId id);
    }
}
