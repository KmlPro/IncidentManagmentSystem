using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UnitTests.Mocks
{
    public class MockDraftApplicationRepository : IDraftApplicationRepository
    {
        public List<DraftApplication> DraftApplications { get; }

        public MockDraftApplicationRepository()
        {
            this.DraftApplications = new List<DraftApplication>();
        }

        public void Delete(DraftApplicationId draftApplicationId)
        {
            var draftApplication = this.DraftApplications.First(x => x.Id == draftApplicationId);
            this.DraftApplications.Remove(draftApplication);
        }

        public Task<DraftApplication> GetById(DraftApplicationId applicationId, CancellationToken cancellationToken)
        {
            var draftApplication = this.DraftApplications.FirstOrDefault(x=> x.Id == applicationId);
            return Task.FromResult(draftApplication);
        }

        public Task Create(DraftApplication draftApplication, CancellationToken cancellationToken)
        {
            this.DraftApplications.Add(draftApplication);
            return Task.CompletedTask;
        }

        public void Update(DraftApplication draftApplication)
        {
            // no implementation required, all changes is see in objects by references
        }
    }
}
