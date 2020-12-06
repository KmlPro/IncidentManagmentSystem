using System.Collections.Generic;
using BuildingBlocks.Application.UnitTests;
using BuildingBlocks.Application.ValidationErrors;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;

namespace IncidentReport.Application.IntegrationTests.UseCases.UpdateDraftApplication
{
    public class UpdateDraftApplicationUseCaseOutputPort : IOutputPort
    {
        public OutputPortInvokedMethod InvokedOutputMethod { get; set; }

        public void Standard(UpdateDraftApplicationOutput output)
        {
            this.InvokedOutputMethod = OutputPortInvokedMethod.Standard;
        }

        public void WriteBusinessRuleError(string message)
        {
            this.InvokedOutputMethod = OutputPortInvokedMethod.WriteBusinessRuleError;
        }

        public void WriteInvalidInput(List<InvalidUseCaseInputValidationError> errors)
        {
            this.InvokedOutputMethod = OutputPortInvokedMethod.WriteInvalidInput;
        }
    }
}
