using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagmentSystem.Web.UseCases.UpdateDraftApplications
{
    public class UpdateDraftApplicationPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void Standard(UpdateDraftApplicationOutput output)
        {
            this.ViewModel = new NoContentResult();
        }

        public void WriteBusinessRuleError(string message)
        {
            this.ViewModel = new UnprocessableEntityObjectResult(message);
        }
    }
}
