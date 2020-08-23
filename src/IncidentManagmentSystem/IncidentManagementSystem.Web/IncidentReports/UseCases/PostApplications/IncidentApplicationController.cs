using System;
using System.Threading.Tasks;
using AutoMapper;
using IncidentReport.Application.Boundaries.PostApplicationUseCase;
using IncidentReport.Infrastructure.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagementSystem.Web.IncidentReports.UseCases.PostApplications
{
    [Route(IncidentReportRoutes.IncidentApplication)]
    [ApiController]
    public class IncidentApplicationController: ControllerBase
    {
        private readonly IIncidentReportModule _incidentReportModule;
        private readonly IMapper _mapper;

        public IncidentApplicationController(IIncidentReportModule incidentReportModule,
            IMapper mapper)
        {
            this._incidentReportModule = incidentReportModule;
            this._mapper = mapper;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostApplication([FromForm] PostApplicationRequest request)
        {
            var useCase = this._mapper.Map<PostApplicationInput>(request);
            var result = await this._incidentReportModule.ExecuteUseCase(useCase);
            var presenter = (PostApplicationPresenter)result;

            return presenter.ViewModel;
        }
    }
}
