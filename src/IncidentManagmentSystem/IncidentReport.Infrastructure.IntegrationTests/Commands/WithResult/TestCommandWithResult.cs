using BuildingBlocks.Application.Commands;

namespace IncidentReport.Infrastructure.IntegrationTests.Commands.WithResult
{
    internal class TestCommandWithResult : CommandBase<TestCommandResult>
    {
        public string TestProperty { get; }

        public TestCommandWithResult(string testProperty)
        {
            this.TestProperty = testProperty;
        }
    }
}
