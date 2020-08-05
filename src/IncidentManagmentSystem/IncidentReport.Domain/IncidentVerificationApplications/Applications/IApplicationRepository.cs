using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.Applications.States;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Applications
{
    public interface IApplicationRepository
    {
        Task<PostedApplication> GetPostedById(ApplicationId applicationId);
        Task Create(CreatedApplication application);
    }
}
