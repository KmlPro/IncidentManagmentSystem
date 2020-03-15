using System;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application;
using BuildingBlocks.Application.Commands;
using MediatR;

namespace IncidentReport.Infrastructure.IntegrationTests.Commands.VoidCommand
{
    internal class TestCommandHandler : ICommandHandler<TestCommand>
    {
        private readonly ICurrentUserContext _currentUserContext;
        public TestCommandHandler(ICurrentUserContext currentUserContext)
        {
            this._currentUserContext = currentUserContext;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<Unit> Handle(TestCommand request, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var userId = this._currentUserContext.UserId;

            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return Unit.Value;
        }
    }
}
