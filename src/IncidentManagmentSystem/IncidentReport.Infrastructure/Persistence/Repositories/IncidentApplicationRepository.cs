using System;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.Applications.States;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.Persistence.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;
using ApplicationId = IncidentReport.Domain.IncidentVerificationApplications.ValueObjects.ApplicationId;

namespace IncidentReport.Infrastructure.Persistence.Repositories
{
    public class IncidentApplicationRepository : IIncidentApplicationRepository
    {
        private IncidentReportWriteDbContext _writeContext;

        public IncidentApplicationRepository(IncidentReportWriteDbContext writeContext)
        {
            this._writeContext = writeContext;
        }

        public async Task<PostedIncidentApplication> GetPostedById(ApplicationId applicationId)
        {
            if (applicationId == null)
            {
                throw new ArgumentNullException(nameof(applicationId));
            }

            try
            {
                var application = await this._writeContext.Application.FirstAsync(x =>
                    x.Id == applicationId && x.ApplicationState == ApplicationStateValue.Posted);
                if (application == null)
                {
                    throw new AggregateNotFoundInDbException(nameof(Application), applicationId.Value);
                }

                return (PostedIncidentApplication)application;
            }
            catch (Exception ex)
            {
                throw new PersistanceException(ex);
            }
        }

        public async Task Create(CreatedIncidentApplication incidentApplication)
        {
            if (incidentApplication == null)
            {
                throw new ArgumentNullException(nameof(incidentApplication));
            }

            try
            {
                await this._writeContext.Application.AddAsync(incidentApplication);
            }
            catch (Exception ex)
            {
                throw new PersistanceException(ex);
            }
        }
    }
}
