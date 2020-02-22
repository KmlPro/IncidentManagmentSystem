using System.Threading.Tasks;
using AutoMapper;
using IncidentManagmentSystem.Web.Controllers.IncidentReports.RequestParameters;
using IncidentReport.Application.IncidentVerificationApplications.CreateIncidentVerificationApplications;
using IncidentReport.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagmentSystem.Web.Controllers.IncidentReports
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IncidentReportController : ControllerBase
    {
        private readonly IIncidentReportModule _incidentReportModule;
        private readonly IMapper _mapper;

        public IncidentReportController(IIncidentReportModule incidentReportModule, IMapper mapper)
        {
            this._incidentReportModule = incidentReportModule;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task CreateIncidentVerificationApplication([FromForm]CreateIncidentVerificationApplicationRequest request)
        {
            var command = this._mapper.Map<CreateIncidentVerificationApplicationCommand>(request);
            await this._incidentReportModule.ExecuteCommandAsync(command);
        }
    }
}