using System;
using System.Threading.Tasks;
using AutoMapper;
using IncidentManagementSystem.Web.Configuration;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Infrastructure.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagementSystem.Web.UseCases.CreateDraftApplications
{
    [Route(Routes.DraftApplication)]
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

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateDraftApplication([FromForm] CreateDraftApplicationRequest request)
        {
            var useCase = this._mapper.Map<CreateDraftApplicationInput>(request);
            var result = await this._incidentReportModule.ExecuteUseCase(useCase);
            var presenter = (CreateDraftApplicationPresenter)result;

            return presenter.ViewModel;
        }
    }
}
