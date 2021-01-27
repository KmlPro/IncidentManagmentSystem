using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.Persistence.Repositories.AsyncGenericRepository;

namespace IncidentReport.Infrastructure.Persistence.Repositories
{
    public class DraftApplicationRepository : IDraftApplicationRepository
    {
        private readonly IAsyncRepository<DraftApplication> _repository;

        public DraftApplicationRepository(IncidentReportWriteDbContext writeContext)
        {
            this._repository = new AsyncRepository<DraftApplication>(writeContext);
        }

        public void Delete(DraftApplicationId draftApplicationId) //kbytner 27.01.2021 - make delete method async
        {
            this._repository.Delete(draftApplicationId, CancellationToken.None); 
        }

        public async Task<DraftApplication> GetById(DraftApplicationId draftApplicationId,
            CancellationToken cancellationToken)
        {
            return await this._repository.GetById(draftApplicationId, cancellationToken);
        }

        public async Task Create(DraftApplication draftApplication, CancellationToken cancellationToken)
        {
            await this._repository.Create(draftApplication, cancellationToken);
        }

        public void Update(DraftApplication draftApplication)
        {
            this._repository.Update(draftApplication);
        }

        public async Task<bool> IsExists(DraftApplicationId draftApplicationId, CancellationToken cancellationToken)
        {
            return await this._repository.IsExists(x => x.Id == draftApplicationId,
                cancellationToken);
        }
    }
}
