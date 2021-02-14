using BuildingBlocks.Application.UseCases;

namespace IncidentReport.Infrastructure.IntegrationTests.UseCases
{
    internal class TestUseCaseInput : IUseCaseInput<TestUseCaseOutput>
    {
        public TestUseCaseInput(string testProperty)
        {
            this.TestProperty = testProperty;
        }

        public string TestProperty { get; }
    }
}
