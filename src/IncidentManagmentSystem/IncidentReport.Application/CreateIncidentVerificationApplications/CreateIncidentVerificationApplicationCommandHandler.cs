using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.Commands;
using IncidentReport.Application.Common;
using IncidentReport.Application.Users;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using MediatR;

namespace IncidentReport.Application.CreateIncidentVerificationApplications
{
    public class CreateIncidentVerificationApplicationCommandHandler : ICommandHandler<CreateIncidentVerificationApplicationCommand>
    {
        private readonly IIncidentReportContext _incidentReportContext;
        private readonly IUserContext _userContext;
        public CreateIncidentVerificationApplicationCommandHandler(IIncidentReportContext incidentReportContext, IUserContext userContext)
        {
            this._incidentReportContext = incidentReportContext;
            this._userContext = userContext;
        }
        public async Task<Unit> Handle(CreateIncidentVerificationApplicationCommand request, CancellationToken cancellationToken)
        {
            var incidentVerificationApplication = IncidentVerificationApplication.Create(
                ContentOfApplication.Create(request.Title, request.Content),
                request.IncidentType,
                this._userContext.UserId
                );

            await this._incidentReportContext.IncidentVerificationApplication.AddAsync(incidentVerificationApplication);

            return Unit.Value;
        }
    }
}
