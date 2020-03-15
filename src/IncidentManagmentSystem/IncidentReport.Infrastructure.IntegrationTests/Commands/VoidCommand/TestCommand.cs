using BuildingBlocks.Application.Commands;

namespace IncidentReport.Infrastructure.IntegrationTests.Commands.VoidCommand
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
