using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.Applications.States;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UnitTests.Mocks
{
    public class MockIncidentApplicationRepository : IIncidentApplicationRepository
    {
        private List<IncidentApplication> _incidentApplications;

        public MockIncidentApplicationRepository()
        {
            this._incidentApplications = new List<IncidentApplication>();
        }

        public Task<PostedIncidentApplication> GetPostedById(IncidentApplicationId incidentApplicationId)
        {
           var postedApplication = this._incidentApplications.FirstOrDefault(x=> x.Id == incidentApplicationId && x.ApplicationState == ApplicationStateValue.Posted);
           return Task.FromResult((PostedIncidentApplication)postedApplication);
        }

        public Task Create(PostedIncidentApplication incidentApplication)
        {
            this._incidentApplications.Add(incidentApplication);
            return Task.CompletedTask;
        }
    }
}
