using System.Threading.Tasks;
using AutoMapper;
using IncidentManagmentSystem.Web.Controllers.IncidentReports.RequestParameters;
using IncidentReport.Application.IncidentVerificationApplications.CreateDraftIncidentVerificationApplications;
using IncidentReport.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagmentSystem.Web.Controllers.IncidentReports
{
    [Route("api/[controller]")]
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
        public async Task CreateIncidentVerificationApplication([FromForm]CreateDraftIncidentVerificationApplicationRequest request)
        {
            var command = this._mapper.Map<CreateDraftIncidentVerificationApplicationCommand>(request);
            await this._incidentReportModule.ExecuteCommandAsync(command);
        }
    }
}
