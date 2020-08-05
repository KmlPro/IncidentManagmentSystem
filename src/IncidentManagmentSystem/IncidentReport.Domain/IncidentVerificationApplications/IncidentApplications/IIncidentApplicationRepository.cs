using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.Applications.States;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications
{
    public interface IIncidentApplicationRepository
    {
        Task<PostedIncidentApplication> GetPostedById(ApplicationId applicationId);
        Task Create(CreatedIncidentApplication incidentApplication);
    }
}
