using IncidentReport.Application.Boundaries.CreateDraftApplications;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagementSystem.Web.IncidentReports.UseCases.CreateDraftApplications
{
    public class CreateDraftApplicationPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void Standard(CreateDraftApplicationOutput output)
        {
            this.ViewModel = new CreatedAtRouteResult(new {id = output.Id}, new { });
        }

        public void WriteBusinessRuleError(string message)
        {
            this.ViewModel = new UnprocessableEntityObjectResult(message);
        }
    }
}
