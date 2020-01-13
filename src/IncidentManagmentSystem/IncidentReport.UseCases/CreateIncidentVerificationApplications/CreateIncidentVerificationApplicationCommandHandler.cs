using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.UseCases.Commands;
using IncidentReport.Application.Common;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;
using IncidentReport.UseCases.User;
using MediatR;

namespace IncidentReport.Application.CreateIncidentVerificationApplications
{
    public class CreateIncidentVerificationApplicationCommandHandler : ICommandHandler<CreateIncidentVerificationApplicationCommand>
    {
        private readonly IIncidentReportContext _incidentReportContext;
        private readonly IApplicantContext _applicantContext;
        public CreateIncidentVerificationApplicationCommandHandler(IIncidentReportContext incidentReportContext, IApplicantContext userContext)
        {
            this._incidentReportContext = incidentReportContext;
            this._applicantContext = userContext;
        }
        public async Task<Unit> Handle(CreateIncidentVerificationApplicationCommand request, CancellationToken cancellationToken)
        {
            var incidentVerificationApplication = IncidentVerificationApplication.Create(
                ContentOfApplication.Create(request.Title, request.Content),
                request.IncidentType,
                UserId.Create(this._applicantContext.UserId)
                );

            await this._incidentReportContext.IncidentVerificationApplication.AddAsync(incidentVerificationApplication);

            return Unit.Value;
        }
    }
}
