using System;
using System.Collections.Generic;
using System.Linq;
using IncidentReport.ReadModels.Contract;
using IncidentReport.ReadModels.Dtos.AuditLogs;
using IncidentReport.ReadModels.Dtos.DraftApplications;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagementSystem.Web.IncidentReports.GetResources
{
    [ApiController]
    [Route(IncidentReportRoutes.IncidentApplication)]
    public class IncidentApplicationController : ControllerBase
    {
        private readonly IIncidentReportReadContext _readContext;

        public IncidentApplicationController(IIncidentReportReadContext readContext)
        {
            this._readContext = readContext;
        }

        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DraftApplicationDto>))]
        public IActionResult Get()
        {
            return this.Ok(this._readContext.IncidentApplications);
        }

        [HttpGet("{id}")]
        [EnableQuery]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DraftApplicationDto))]
        public IActionResult Get(Guid id)
        {
            return this.Ok(this._readContext.IncidentApplications.Where(x => x.Id == id));
        }
    }
}
