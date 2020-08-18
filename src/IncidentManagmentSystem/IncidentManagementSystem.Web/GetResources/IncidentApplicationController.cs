using System;
using System.Collections.Generic;
using System.Linq;
using IncidentManagementSystem.Web.Configuration;
using IncidentReport.ReadModels.Contract;
using IncidentReport.ReadModels.Dtos.DraftApplications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagementSystem.Web.GetResources
{
    [Route(Routes.IncidentApplication)]
    [ApiController]
    public class IncidentApplicationController : ControllerBase
    {
        private readonly IIncidentReportReadContext _readContext;

        public IncidentApplicationController(IIncidentReportReadContext readContext)
        {
            this._readContext = readContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DraftApplicationDto>))]
        public IActionResult Get()
        {
            return this.Ok(this._readContext.IncidentApplications);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DraftApplicationDto))]
        public IActionResult Get(Guid id)
        {
            return this.Ok(this._readContext.IncidentApplications.Where(x => x.Id == id));
        }
    }
}
