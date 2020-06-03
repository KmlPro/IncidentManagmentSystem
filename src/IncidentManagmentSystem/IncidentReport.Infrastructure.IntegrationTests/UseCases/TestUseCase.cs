using System;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application;

namespace IncidentReport.Infrastructure.IntegrationTests.UseCases
{
    internal class TestUseCase : IUseCase
    {
        private readonly ICurrentUserContext _currentUserContext;

        public TestUseCase(ICurrentUserContext currentUserContext)
        {
            this._currentUserContext = currentUserContext;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<TestUseCaseOutput> Handle(TestUseCaseInput request, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var userId = this._currentUserContext.UserId;

            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return new TestUseCaseOutput();
        }
    }
}
