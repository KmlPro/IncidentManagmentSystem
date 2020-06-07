using System;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;

namespace IncidentReport.Application.UnitTests.UseCases.UpdateDraftApplication
{
    public class UpdateDraftApplicationUseCaseOutputPort : IOutputPort
    {
        public OutputPortInvokedMethod InvokedOutputMethod { get; set; }
        public Guid Id { get; set; }

        public void Standard(UpdateDraftApplicationOutput output)
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
