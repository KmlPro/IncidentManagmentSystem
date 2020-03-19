using BuildingBlocks.Application.UseCases;

namespace IncidentReport.Infrastructure.IntegrationTests.UseCases
{
    internal class TestUseCaseInput : IUseCaseInput<TestUseCaseOutput>
    {
        public string TestProperty { get; }

        public TestUseCaseInput(string testProperty)
        {
            this.TestProperty = testProperty;
        }
    }
}
