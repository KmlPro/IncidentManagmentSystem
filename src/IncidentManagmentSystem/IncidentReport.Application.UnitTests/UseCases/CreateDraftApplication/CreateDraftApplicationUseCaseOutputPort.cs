using System;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.Boundaries.CreateDraftApplications;

namespace IncidentReport.Application.UnitTests.UseCases.CreateDraftApplication
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
    }
}
