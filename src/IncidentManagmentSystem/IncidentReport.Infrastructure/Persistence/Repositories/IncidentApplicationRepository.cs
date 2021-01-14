using System;
using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.AuditLogs;
using IncidentReport.Infrastructure.Persistence.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.Repositories
{
    public class IncidentApplicationRepository : IIncidentApplicationRepository
    {
        private IncidentReportWriteDbContext _writeContext;
        private readonly AuditLogService _auditLogService;

        public IncidentApplicationRepository(IncidentReportWriteDbContext writeContext, AuditLogService auditLogService)
        {
            this._writeContext = writeContext;
            this._auditLogService = auditLogService;
        }

        public async Task<IncidentApplication> GetPostedById(IncidentApplicationId incidentApplicationId, CancellationToken cancellationToken)
        {
            if (incidentApplicationId == null)
            {
                throw new ArgumentNullException(nameof(incidentApplicationId));
            }

            try
            {
                var application = await this._writeContext.IncidentApplication.FirstAsync(x =>
                    x.Id == incidentApplicationId, cancellationToken);

                if (application == null)
                {
                    throw new AggregateNotFoundInDbException(nameof(Application), incidentApplicationId.Value);
                }

                return application;
            }
            catch (Exception ex)
            {
                throw new PersistanceException(ex);
            }
        }

        public async Task Create(IncidentApplication incidentApplication,CancellationToken cancellationToken)
        {
            if (incidentApplication == null)
            {
                throw new ArgumentNullException(nameof(incidentApplication));
            }

            try
            {
                await this._writeContext.IncidentApplication.AddAsync(incidentApplication,cancellationToken);
                // if (CheckIsEntityHasDomainEvents.Check(incidentApplication))
                // {
                //     await this._writeContext.ApplicationAuditLog.AddRangeAsync(
                //         this._auditLogService.CreateFromDomainEvents<ApplicationAuditLog>(incidentApplication), cancellationToken);
                // }
            }
            catch (Exception ex)
            {
                throw new PersistanceException(ex);
            }
        }

        public async Task<bool> IsExists(IncidentApplicationId incidentApplicationId, CancellationToken cancellationToken)
        {
            return await this._writeContext.IncidentApplication.AnyAsync(x => x.Id == incidentApplicationId, cancellationToken);
        }
    }
}
