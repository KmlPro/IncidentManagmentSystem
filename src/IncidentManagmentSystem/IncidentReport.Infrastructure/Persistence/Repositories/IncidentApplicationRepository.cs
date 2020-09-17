using System;
using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications.States;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
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

        public async Task<PostedIncidentApplication> GetPostedById(IncidentApplicationId incidentApplicationId, CancellationToken cancellationToken)
        {
            if (incidentApplicationId == null)
            {
                throw new ArgumentNullException(nameof(incidentApplicationId));
            }

            try
            {
                var application = await this._writeContext.IncidentApplication.FirstAsync(x =>
                    x.Id == incidentApplicationId && x.ApplicationState == ApplicationStateValue.Posted, cancellationToken);
                if (application == null)
                {
                    throw new AggregateNotFoundInDbException(nameof(Application), incidentApplicationId.Value);
                }

                return (PostedIncidentApplication)application;
            }
            catch (Exception ex)
            {
                throw new PersistanceException(ex);
            }
        }

        public async Task Create(PostedIncidentApplication incidentApplication,CancellationToken cancellationToken)
        {
            if (incidentApplication == null)
            {
                throw new ArgumentNullException(nameof(incidentApplication));
            }

            try
            {
                await this._writeContext.IncidentApplication.AddAsync(incidentApplication,cancellationToken);
            }
            catch (Exception ex)
            {
                throw new PersistanceException(ex);
            }
        }
    }
}
