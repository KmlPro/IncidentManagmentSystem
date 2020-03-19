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

        public async Task<TestUseCaseOutput> Handle(TestUseCaseInput request, CancellationToken cancellationToken)
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
