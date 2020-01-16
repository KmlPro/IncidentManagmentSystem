using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.Commands;
using IncidentReport.Application.Common;
using IncidentReport.Application.User;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;
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
            var incidentVerificationApplication = NewIncidentVerificationApplication.Create(
                ContentOfApplication.Create(request.Title, request.Content),
                request.IncidentType,
                UserId.Create(request.ApplicantId),
                SuspiciousEmployees.Create(request.SuspiciousEmployees),
                UserId.Create(this._applicantContext.UserId)
                );
            ;

            var x = incidentVerificationApplication.SendToVerification();

            await this._incidentReportContext.IncidentVerificationApplication.AddAsync(incidentVerificationApplication);

            return Unit.Value;
        }
    }
}
