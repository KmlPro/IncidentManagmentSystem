using IncidentReport.Application.Boundaries.CreateDraftApplications;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagmentSystem.Web.UseCases.CreateDraftApplications
{
    public class CreateDraftApplicationPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void Standard(CreateDraftApplicationOutput output)
        {
            this.ViewModel = new CreatedAtRouteResult(
                new { id = output.DraftApplication.Id.Value },
                output.DraftApplication);
        }

        public void WriteBusinessRuleError(string message)
        {
            this.ViewModel = new UnprocessableEntityObjectResult(message);
        }
    }
}
