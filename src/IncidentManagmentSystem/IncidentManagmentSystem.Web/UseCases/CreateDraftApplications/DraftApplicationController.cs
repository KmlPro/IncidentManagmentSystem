using System.Threading.Tasks;
using AutoMapper;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagmentSystem.Web.UseCases.CreateDraftApplications
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
            var useCase = this._mapper.Map<CreateDraftApplicationInput>(request);
            await this._incidentReportModule.ExecuteUseCase(useCase);

            //  return Ok();
            //     return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }
    }
}
