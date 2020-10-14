using System;
using System.Collections.Generic;
using System.Linq;
using IncidentReport.ReadModels.Contract;
using IncidentReport.ReadModels.Dtos.AuditLogs;
using IncidentReport.ReadModels.Dtos.DraftApplications;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagementSystem.Web.IncidentReports.GetResources
{
    [ApiController]
    [Route(IncidentReportRoutes.DraftApplication)]
    public class DraftApplicationController : ODataController
    {
        private readonly IIncidentReportReadContext _readContext;

        public DraftApplicationController(IIncidentReportReadContext readContext)
        {
            this._readContext = readContext;
        }

        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DraftApplicationDto>))]
        public IActionResult Get()
        {
            return this.Ok(this._readContext.DraftApplications);
        }

        [HttpGet("{id}")]
        [EnableQuery]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DraftApplicationDto))]
        public IActionResult Get(Guid id)
        {
            return this.Ok(this._readContext.DraftApplications.Where(x => x.Id == id));
        }

        [HttpGet("{id}/history")]
        [EnableQuery]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AuditLogDto>))]
        public IActionResult GetHistory(Guid id)
        {
            return this.Ok(this._readContext.DraftApplicationAuditLogs.Where(x => x.EntityId == id.ToString()));
        }
    }
}
