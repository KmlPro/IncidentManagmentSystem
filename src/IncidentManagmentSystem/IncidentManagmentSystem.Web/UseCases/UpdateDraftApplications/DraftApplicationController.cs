using System.Threading.Tasks;
using AutoMapper;
using IncidentManagmentSystem.Web.Configuration;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Infrastructure.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagmentSystem.Web.UseCases.UpdateDraftApplications
{
    [Route(ConstRoute.StandardRoute)]
    [ApiController]
    public class DraftApplicationController : ControllerBase
    {
        private readonly IIncidentReportModule _incidentReportModule;
        private readonly IMapper _mapper;

        public DraftApplicationController(IIncidentReportModule incidentReportModule,
            IMapper mapper)
        {
            this._incidentReportModule = incidentReportModule;
            this._mapper = mapper;
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDraftApplication([FromForm] UpdateDraftApplicationRequest request)
        {
            var useCase = this._mapper.Map<UpdateDraftApplicationInput>(request);
            var result = await this._incidentReportModule.ExecuteUseCase(useCase);
            var presenter = (UpdateDraftApplicationPresenter)result;

            return presenter.ViewModel;
        }
    }
}
