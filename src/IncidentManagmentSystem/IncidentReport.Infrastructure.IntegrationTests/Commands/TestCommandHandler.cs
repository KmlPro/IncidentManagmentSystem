using System;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application;
using BuildingBlocks.Application.Commands;
using IncidentReport.Infrastructure.IntegrationTests.Common.Commands;
using MediatR;

namespace IncidentReport.Infrastructure.IntegrationTests.Commands
{
    internal class TestCommandHandler : ICommandHandler<TestCommand>
    {
        private readonly ICurrentUserContext _currentUserContext;
        public TestCommandHandler(ICurrentUserContext currentUserContext)
        {
            this._currentUserContext = currentUserContext;
        }

        public async Task<Unit> Handle(TestCommand request, CancellationToken cancellationToken)
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
