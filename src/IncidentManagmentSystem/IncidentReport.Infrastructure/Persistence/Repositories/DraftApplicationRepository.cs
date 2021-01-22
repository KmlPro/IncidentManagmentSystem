using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.AuditLogs;
using IncidentReport.Infrastructure.Persistence.NotDomainEntities;
using IncidentReport.Infrastructure.Persistence.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.Repositories
{
    public class DraftApplicationRepository : IDraftApplicationRepository
    {
        private readonly IncidentReportWriteDbContext _writeContext;

        public DraftApplicationRepository(IncidentReportWriteDbContext writeContext, AuditLogService auditLogService)
        {
            this._writeContext = writeContext;
        }

        public async void Delete(DraftApplicationId draftApplicationId)
        {
            if (draftApplicationId == null)
            {
                throw new ArgumentNullException(nameof(draftApplicationId));
            }


            var draftApplication = await this._writeContext.DraftApplication.FirstAsync(x =>
                x.Id == draftApplicationId);
            this._writeContext.DraftApplication.Remove(draftApplication);
        }

        public async Task<DraftApplication> GetById(DraftApplicationId draftApplicationId,
            CancellationToken cancellationToken)
        {
            if (draftApplicationId == null)
            {
                throw new ArgumentNullException(nameof(draftApplicationId));
            }

            var draftApplication = await this._writeContext.DraftApplication
                .Include(nameof(DraftApplication.Attachments)).FirstAsync(x =>
                    x.Id == draftApplicationId, cancellationToken);

            if (draftApplication == null)
            {
                throw new AggregateNotFoundInDbException(nameof(Application), draftApplicationId.Value);
            }

            return draftApplication;
        }

        public async Task Create(DraftApplication draftApplication, CancellationToken cancellationToken)
        {
            if (draftApplication == null)
            {
                throw new ArgumentNullException(nameof(draftApplication));
            }

            await this._writeContext.DraftApplication.AddAsync(draftApplication, cancellationToken);
        }

        public void Update(DraftApplication draftApplication)
        {
            if (draftApplication == null)
            {
                throw new ArgumentNullException(nameof(draftApplication));
            }


            this._writeContext.DraftApplication.Update(draftApplication);
        }

        public async Task<bool> IsExists(DraftApplicationId draftApplicationId, CancellationToken cancellationToken)
        {
            return await this._writeContext.DraftApplication.AnyAsync(x => x.Id == draftApplicationId,
                cancellationToken);
        }
    }
}
