using System.Collections.Generic;
using BuildingBlocks.Application.ValidationErrors;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagementSystem.Web.IncidentReports.UseCases.UpdateDraftApplications
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

        //kbytner 12.11.2020 - to do choose http code and map validation errors
        public void WriteInvalidInput(List<InvalidUseCaseInputValidationError> errors)
        {
            this.ViewModel = new BadRequestResult();
        }
    }
}
