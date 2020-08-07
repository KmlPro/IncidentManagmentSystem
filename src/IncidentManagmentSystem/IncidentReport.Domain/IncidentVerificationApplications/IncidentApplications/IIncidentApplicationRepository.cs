using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.Applications.States;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications.States;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications
{
    public interface IIncidentApplicationRepository
    {
        Task<PostedIncidentApplication> GetPostedById(IncidentApplicationId incidentApplicationId);
        Task Create(PostedIncidentApplication incidentApplication);
    }
}
