using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.IntegrationTests.Mocks
{
    public class MockIncidentApplicationRepository : IIncidentApplicationRepository
    {
        public List<IncidentApplication> IncidentApplications { get; }

        public MockIncidentApplicationRepository()
        {
            this.IncidentApplications = new List<IncidentApplication>();
        }

        public Task<IncidentApplication> GetPostedById(IncidentApplicationId incidentApplicationId, CancellationToken cancellationToken)
        {
           var postedApplication = this.IncidentApplications.FirstOrDefault(x=> x.Id == incidentApplicationId && x.ApplicationState == ApplicationStateValue.Posted);
           return Task.FromResult((IncidentApplication)postedApplication);
        }

        public Task Create(IncidentApplication incidentApplication,CancellationToken cancellationToken)
        {
            this.IncidentApplications.Add(incidentApplication);
            return Task.CompletedTask;
        }

        public Task<bool> IsExists(IncidentApplicationId draftApplicationId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
