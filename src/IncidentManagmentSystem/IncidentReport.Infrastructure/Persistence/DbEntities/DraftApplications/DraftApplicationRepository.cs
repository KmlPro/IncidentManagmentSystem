using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Infrastructure.Persistence.DbEntities.DraftApplications
{
    public class DraftApplicationRepository : IDraftApplicationRepository
    {
        private readonly IncidentReportDbContext _incidentReportDbContext;

        public DraftApplicationRepository(IncidentReportDbContext incidentReportDbContext)
        {
            this._incidentReportDbContext = incidentReportDbContext;
        }
        public Task<DraftApplication> GetById(DraftApplicationId id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void Update(DraftApplication draftApplication)
        {
            throw new System.NotImplementedException();
        }

        public Task Add(DraftApplication draftApplication, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(DraftApplicationId id)
        {
            throw new System.NotImplementedException();
        }
    }
}
