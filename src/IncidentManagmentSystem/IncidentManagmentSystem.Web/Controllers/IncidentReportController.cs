using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using IncidentManagmentSystem.Web.Controllers.RequestParameters.IncidentReport;
using IncidentReport.Application.IncidentVerificationApplications.CreateIncidentVerificationApplications;
using IncidentReport.Infrastructure.Contract;

namespace IncidentManagmentSystem.Web.Controllers
{
    public class IncidentReportController : ApiController
    {
        private readonly IIncidentReportModule _incidentReportModule;
        private readonly IMapper _mapper;

        public IncidentReportController(IIncidentReportModule incidentReportModule, IMapper mapper)
        {
            this._incidentReportModule = incidentReportModule;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task CreateIncidentVerificationApplication(CreateIncidentVerificationApplicationRequest request)
        {
            var command = this._mapper.Map<CreateIncidentVerificationApplicationCommand>(request);
            await this._incidentReportModule.ExecuteCommandAsync(command);
        }
    }
}
