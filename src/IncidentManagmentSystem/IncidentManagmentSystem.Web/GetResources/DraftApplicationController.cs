using System;
using System.Linq;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.ReadModels.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagmentSystem.Web.GetResources
{
    [Route("api/[controller]")]
    [ApiController]
    public class DraftApplicationController : ControllerBase
    {
        private readonly IIncidentReportReadContext _readContext;

        public DraftApplicationController(IIncidentReportReadContext readContext)
        {
            this._readContext = readContext;
        }

        [HttpGet]
        // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DraftApplicationDto))]
        public IActionResult Get(Guid id)
        {
            return this.Ok(this._readContext.DraftApplications.Where(x => x.Id == id));
        }
    }
}
