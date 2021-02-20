using System.Threading.Tasks;
using Autofac;
using BuildingBlocks.Application.UseCases;
using IncidentReport.Infrastructure.DIContainer;
using MediatR;

namespace IncidentReport.Infrastructure.Processing.UseCases
{
    internal class UseCaseExecutor
    {
        internal static async Task<TUseCaseOutput> Execute<TUseCaseOutput>(IUseCaseInput<TUseCaseOutput> useCase)
            where TUseCaseOutput : IUseCaseOutput
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var _mediator = scope.Resolve<IMediator>();

                return await _mediator.Send(useCase);
            }
        }
    }
}
