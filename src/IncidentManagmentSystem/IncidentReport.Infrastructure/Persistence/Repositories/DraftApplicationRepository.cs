using System;
using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.AuditLogs;
using IncidentReport.Infrastructure.Persistence.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.Repositories
{
    public class DraftApplicationRepository : IDraftApplicationRepository
    {
        private IncidentReportWriteDbContext _writeContext;
        private AuditLogFactory _auditLogFactory;

        public DraftApplicationRepository(IncidentReportWriteDbContext writeContext, AuditLogFactory auditLogFactory)
        {
            this._writeContext = writeContext;
            this._auditLogFactory = auditLogFactory;
        }

        public async void Delete(DraftApplicationId draftApplicationId)
        {
            if (draftApplicationId == null)
            {
                throw new ArgumentNullException(nameof(draftApplicationId));
            }

            try
            {
                var draftApplication = await this._writeContext.DraftApplication.FirstAsync(x =>
                    x.Id == draftApplicationId);
                this._writeContext.DraftApplication.Remove(draftApplication);
            }
            catch (Exception ex)
            {
                throw new PersistanceException(ex);
            }
        }

        public async Task<DraftApplication> GetById(DraftApplicationId draftApplicationId, CancellationToken cancellationToken)
        {
            if (draftApplicationId == null)
            {
                throw new ArgumentNullException(nameof(draftApplicationId));
            }

            try
            {
                var draftApplication = await this._writeContext.DraftApplication.Include(nameof(DraftApplication.Attachments)).FirstAsync(x =>
                    x.Id == draftApplicationId,cancellationToken);

                if (draftApplication == null)
                {
                    throw new AggregateNotFoundInDbException(nameof(Application), draftApplicationId.Value);
                }

                return draftApplication;
            }
            catch (Exception ex)
            {
                throw new PersistanceException(ex);
            }
        }

        public async Task Create(DraftApplication draftApplication, CancellationToken cancellationToken)
        {
            if (draftApplication == null)
            {
                throw new ArgumentNullException(nameof(draftApplication));
            }

            try
            {
                await this._writeContext.DraftApplication.AddAsync(draftApplication,cancellationToken);
                if (CheckIsEntityHaveDomainEvents.Check(draftApplication))
                {
                    await this._writeContext.DraftApplicationAuditLogs.AddRangeAsync(
                        this._auditLogFactory.CreateFromDomainEvents(draftApplication), cancellationToken);
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceException(ex);
            }
        }

        public void Update(DraftApplication draftApplication)
        {
            if (draftApplication == null)
            {
                throw new ArgumentNullException(nameof(draftApplication));
            }

            try
            {
                this._writeContext.DraftApplication.Update(draftApplication);
                if (CheckIsEntityHaveDomainEvents.Check(draftApplication))
                {
                    this._writeContext.DraftApplicationAuditLogs.AddRange(
                        this._auditLogFactory.CreateFromDomainEvents(draftApplication));
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceException(ex);
            }
        }
    }
}
