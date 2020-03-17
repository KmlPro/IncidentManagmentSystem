using BuildingBlocks.Application.UseCases;

namespace IncidentReport.Infrastructure.IntegrationTests.UseCases
{
    public class TestUseCaseInput : IUseCaseInput
    {
        public string TestProperty { get; }

        public TestUseCaseInput(string testProperty)
        {
            this.TestProperty = testProperty;
        }
    }
}
