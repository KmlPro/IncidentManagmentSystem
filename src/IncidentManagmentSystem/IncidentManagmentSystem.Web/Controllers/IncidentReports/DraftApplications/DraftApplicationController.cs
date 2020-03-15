using System.Threading.Tasks;
using AutoMapper;
using IncidentManagmentSystem.Web.Controllers.IncidentReports.DraftApplications.RequestParameters;
using IncidentReport.Application.IncidentVerificationApplications.CreateDraftIncidentVerificationApplications;
using IncidentReport.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagmentSystem.Web.Controllers.IncidentReports.DraftApplications
{
    [Route("api/[controller]")]
    [ApiController]
    public class DraftApplicationController : ControllerBase
    {
        private readonly IIncidentReportModule _incidentReportModule;
        private readonly IMapper _mapper;

        public DraftApplicationController(IIncidentReportModule incidentReportModule, IMapper mapper)
        {
            this._incidentReportModule = incidentReportModule;
            this._mapper = mapper;
        }

        //to do return URI
        [HttpPost]
        public async Task Post([FromForm]CreateDraftApplicationRequest request)
        {
            var command = this._mapper.Map<CreateDraftApplicationCommand>(request);
            var result = await this._incidentReportModule.ExecuteCommandWithResultAsync(command);

            //  return Ok();
            //     return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }
    }
}
