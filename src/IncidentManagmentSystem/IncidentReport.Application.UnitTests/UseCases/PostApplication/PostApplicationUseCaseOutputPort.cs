using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.Boundaries.PostApplicationUseCase;

namespace IncidentReport.Application.UnitTests.UseCases.PostApplication
{
    public class PostApplicationUseCaseOutputPort : IOutputPort
    {
        public OutputPortInvokedMethod InvokedOutputMethod { get; set; }

        public void Standard(PostApplicationOutput output)
        {
            this.InvokedOutputMethod = OutputPortInvokedMethod.Standard;
        }

        public void WriteBusinessRuleError(string message)
        {
            this.InvokedOutputMethod = OutputPortInvokedMethod.WriteBusinessRuleError;
        }
    }
}
