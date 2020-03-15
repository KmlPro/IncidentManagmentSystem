using System;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application;
using BuildingBlocks.Application.Commands;
using IncidentReport.Infrastructure.IntegrationTests.Commands.WithResult;

namespace IncidentReport.Infrastructure.IntegrationTests.Commands.VoidCommand
{
    internal class TestCommandWithResultHandler : ICommandHandlerWithResult<TestCommandWithResult, TestCommandResult>
    {
        private readonly ICurrentUserContext _currentUserContext;
        public TestCommandWithResultHandler(ICurrentUserContext currentUserContext)
        {
            this._currentUserContext = currentUserContext;
        }

        public async Task<TestCommandResult> Handle(TestCommandWithResult request, CancellationToken cancellationToken)
        {
            var userId = this._currentUserContext.UserId;

            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return new TestCommandResult();
        }
    }
}
