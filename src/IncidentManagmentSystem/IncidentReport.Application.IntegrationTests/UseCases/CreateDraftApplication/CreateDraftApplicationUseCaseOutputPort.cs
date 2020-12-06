using System;
using System.Collections.Generic;
using BuildingBlocks.Application.UnitTests;
using BuildingBlocks.Application.ValidationErrors;
using IncidentReport.Application.Boundaries.CreateDraftApplications;

namespace IncidentReport.Application.IntegrationTests.UseCases.CreateDraftApplication
{
    public class CreateDraftApplicationUseCaseOutputPort : IOutputPort
    {
        public OutputPortInvokedMethod InvokedOutputMethod { get; set; }
        public Guid Id { get; set; }

        public void Standard(CreateDraftApplicationOutput output)
        {
            this.InvokedOutputMethod = OutputPortInvokedMethod.Standard;
            this.Id = output.Id;
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
