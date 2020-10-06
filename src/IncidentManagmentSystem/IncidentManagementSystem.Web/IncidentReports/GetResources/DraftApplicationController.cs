using System;
using System.Collections.Generic;
using System.Linq;
using IncidentManagementSystem.Web.Configuration;
using IncidentReport.ReadModels.Contract;
using IncidentReport.ReadModels.Dtos.AuditLogs;
using IncidentReport.ReadModels.Dtos.DraftApplications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagementSystem.Web.IncidentReports.GetResources
{
    [Route(IncidentReportRoutes.DraftApplication)]
    [ApiController]
    public class DraftApplicationController : ControllerBase
    {
        private readonly IIncidentReportReadContext _readContext;

        public DraftApplicationController(IIncidentReportReadContext readContext)
        {
            this._readContext = readContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DraftApplicationDto>))]
        public IActionResult Get()
        {
            return this.Ok(this._readContext.DraftApplications);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DraftApplicationDto))]
        public IActionResult Get(Guid id)
        {
            return this.Ok(this._readContext.DraftApplications.Where(x => x.Id == id));
        }

        [Route("{id}/history")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AuditLogDto>))]
        public IActionResult GetHistory(Guid id)
        {
            return this.Ok(this._readContext.DraftApplicationAuditLogs.Where(x => x.EntityId == id.ToString()));
        }
    }
}
