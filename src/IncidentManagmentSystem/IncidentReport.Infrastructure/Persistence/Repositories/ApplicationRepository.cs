using System;
using System.Threading.Tasks;
using IncidentReport.Domain.IncidentVerificationApplications.Applications;
using IncidentReport.Domain.IncidentVerificationApplications.Applications.States;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.Persistence.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;
using ApplicationId = IncidentReport.Domain.IncidentVerificationApplications.ValueObjects.ApplicationId;
using Application = IncidentReport.Domain.IncidentVerificationApplications.Applications.Application;

namespace IncidentReport.Infrastructure.Persistence.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private IncidentReportWriteDbContext _writeContext;

        public ApplicationRepository(IncidentReportWriteDbContext writeContext)
        {
            this._writeContext = writeContext;
        }

        public async Task<PostedApplication> GetPostedById(ApplicationId applicationId)
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

                return (PostedApplication)application;
            }
            catch (Exception ex)
            {
                throw new PersistanceException(ex);
            }
        }

        public async Task Create(CreatedApplication application)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }

            try
            {
                await this._writeContext.Application.AddAsync(application);
            }
            catch (Exception ex)
            {
                throw new PersistanceException(ex);
            }
        }
    }
}
