using System;
using System.Linq;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.PublicDomain.DraftApplications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagmentSystem.Web.GetResources
{
    [Route("api/[controller]")]
    [ApiController]
    public class DraftApplicationController : ControllerBase
    {
        private readonly IIncidentReportModule _incidentReportModule;

        public DraftApplicationController(IIncidentReportModule incidentReportModule)
        {
            this._incidentReportModule = incidentReportModule;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DraftApplicationDto))]
        public IActionResult Get(Guid id)
        {
            return this.Ok(this._incidentReportModule.ReadContext.DraftApplications.Where(x => x.Id == id));
        }
    }
}
