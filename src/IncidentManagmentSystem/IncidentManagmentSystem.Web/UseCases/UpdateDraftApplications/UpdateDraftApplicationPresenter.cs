using IncidentReport.Application.Boundaries.CreateDraftApplications;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagmentSystem.Web.UseCases.UpdateDraftApplications
{
    public class UpdateDraftApplicationPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void Standard(CreateDraftApplicationOutput output)
        {
            this.ViewModel = new NoContentResult();
        }

        public void WriteBusinessRuleError(string message)
        {
            this.ViewModel = new UnprocessableEntityObjectResult(message);
        }
    }
}
