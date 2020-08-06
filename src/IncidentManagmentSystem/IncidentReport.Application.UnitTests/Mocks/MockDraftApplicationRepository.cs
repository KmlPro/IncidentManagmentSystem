using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UnitTests.Mocks
{
    public class MockDraftApplicationRepository : IDraftApplicationRepository
    {
        private List<DraftApplication> _draftApplications;

        public MockDraftApplicationRepository()
        {
            this._draftApplications = new List<DraftApplication>();
        }

        public void Delete(DraftApplicationId draftApplicationId)
        {
            var draftApplication = this._draftApplications.First(x => x.Id == draftApplicationId);
            this._draftApplications.Remove(draftApplication);
        }

        public Task<DraftApplication> GetById(DraftApplicationId applicationId)
        {
            var draftApplication = this._draftApplications.FirstOrDefault(x=> x.Id == applicationId);
            return Task.FromResult(draftApplication);
        }

        public Task Create(DraftApplication draftApplication)
        {
            this._draftApplications.Add(draftApplication);
            return Task.CompletedTask;
        }

        public void Update(DraftApplication draftApplication)
        {
            // no implementation required, all changes is see in objects by references
        }
    }
}
