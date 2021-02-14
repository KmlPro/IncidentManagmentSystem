using System;
using System.Collections.Generic;
using BuildingBlocks.Application.UnitTests;
using BuildingBlocks.Application.ValidationErrors;
using IncidentReport.Application.Boundaries.PostApplicationUseCase;

namespace IncidentReport.Application.IntegrationTests.UseCases.PostApplication
{
    public class PostApplicationUseCaseOutputPort : IOutputPort
    {
        public OutputPortInvokedMethod InvokedOutputMethod { get; set; }
        public Guid Id { get; private set; }

        public void Standard(PostApplicationOutput output)
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
