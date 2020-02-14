using BuildingBlocks.Application.Commands;

namespace IncidentReport.Infrastructure.IntegrationTests.Common.Commands
{
    internal class TestCommand : CommandBase
    {
        public string TestProperty { get; }

        public TestCommand(string testProperty)
        {
            this.TestProperty = testProperty;
        }
    }
}
