using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.Applications.States;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications.States;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UnitTests.Mocks
{
    public class MockIncidentApplicationRepository : IIncidentApplicationRepository
    {
        public List<IncidentApplication> IncidentApplications { get; }

        public MockIncidentApplicationRepository()
        {
            this.IncidentApplications = new List<IncidentApplication>();
        }

        public Task<PostedIncidentApplication> GetPostedById(IncidentApplicationId incidentApplicationId, CancellationToken cancellationToken)
        {
           var postedApplication = this.IncidentApplications.FirstOrDefault(x=> x.Id == incidentApplicationId && x.ApplicationState == ApplicationStateValue.Posted);
           return Task.FromResult((PostedIncidentApplication)postedApplication);
        }

        public Task Create(PostedIncidentApplication incidentApplication,CancellationToken cancellationToken)
        {
            this.IncidentApplications.Add(incidentApplication);
            return Task.CompletedTask;
        }
    }
}
