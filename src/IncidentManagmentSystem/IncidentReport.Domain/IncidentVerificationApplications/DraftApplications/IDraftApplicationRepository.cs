using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.DraftApplications
{
    public interface IDraftApplicationRepository
    {
        void Delete(DraftApplicationId draftApplicationId);
        Task<DraftApplication> GetById(DraftApplicationId applicationId);
        Task Create(DraftApplication draftApplication);
        void Update(DraftApplication draftApplication);
    }
}
