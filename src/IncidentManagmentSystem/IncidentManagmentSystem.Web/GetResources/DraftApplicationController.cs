using System;
using System.Threading.Tasks;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagmentSystem.Web.GetResources
{
    [Route("api/[controller]")]
    [ApiController]
    public class DraftApplicationController : ControllerBase
    {
        public DraftApplicationController()
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        public async Task<IActionResult> Get(Guid guid)
        {
            return this.Ok(Guid.NewGuid());
        }
    }
}
