using System.Threading.Tasks;
using AutoMapper;
using IncidentManagmentSystem.Web.Controllers.IncidentReports.DraftIncidentVerificationApplications.RequestParameters;
using IncidentReport.Application.IncidentVerificationApplications.CreateDraftIncidentVerificationApplications;
using IncidentReport.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagmentSystem.Web.Controllers.IncidentReports.DraftIncidentVerificationApplications
{
    [Route("api/[controller]")]
    [ApiController]
    public class DraftIncidentVerificationApplicationController : ControllerBase
    {
        private readonly IIncidentReportModule _incidentReportModule;
        private readonly IMapper _mapper;

        public DraftIncidentVerificationApplicationController(IIncidentReportModule incidentReportModule, IMapper mapper)
        {
            this._incidentReportModule = incidentReportModule;
            this._mapper = mapper;
        }

        //to do return URI
        [HttpPost]
        public async Task Post([FromForm]CreateDraftIncidentVerificationApplicationRequest request)
        {
            var command = this._mapper.Map<CreateDraftIncidentVerificationApplicationCommand>(request);
            var result = await this._incidentReportModule.ExecuteCommandWithResultAsync(command);

            //  return Ok();
            //     return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }
    }
}
