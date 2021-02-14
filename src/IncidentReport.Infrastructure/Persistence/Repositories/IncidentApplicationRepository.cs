using System;
using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.Aggregates.IncidentApplications;
using IncidentReport.Domain.ValueObjects;
using IncidentReport.Infrastructure.Persistence.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.Repositories
{
    public class IncidentApplicationRepository : IIncidentApplicationRepository
    {
        private IncidentReportWriteDbContext _writeContext;

        public IncidentApplicationRepository(IncidentReportWriteDbContext writeContext)
        {
            this._writeContext = writeContext;
        }

        public async Task<IncidentApplication> GetPostedById(IncidentApplicationId incidentApplicationId,
            CancellationToken cancellationToken)
        {
            if (incidentApplicationId == null)
            {
                throw new ArgumentNullException(nameof(incidentApplicationId));
            }

            var application = await this._writeContext.IncidentApplication.FirstAsync(x =>
                x.Id == incidentApplicationId, cancellationToken);

            if (application == null)
            {
                throw new AggregateNotFoundInDbException(nameof(Application), incidentApplicationId.Value);
            }

            return application;
        }

        public async Task Create(IncidentApplication incidentApplication, CancellationToken cancellationToken)
        {
            if (incidentApplication == null)
            {
                throw new ArgumentNullException(nameof(incidentApplication));
            }

            await this._writeContext.IncidentApplication.AddAsync(incidentApplication, cancellationToken);
        }

        public async Task<bool> IsExists(IncidentApplicationId incidentApplicationId,
            CancellationToken cancellationToken)
        {
            return await this._writeContext.IncidentApplication.AnyAsync(x => x.Id == incidentApplicationId,
                cancellationToken);
        }
    }
}
