using IncidentReport.Application.Boundaries.PostApplicationUseCase;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagementSystem.Web.UseCases.PostApplications
{
    public class PostApplicationPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void WriteBusinessRuleError(string message)
        {
            this.ViewModel = new UnprocessableEntityObjectResult(message);
        }

        public void Standard(PostApplicationOutput output)
        {
            this.ViewModel = new CreatedAtRouteResult(new {id = output.Id}, new { });
        }
    }
}
