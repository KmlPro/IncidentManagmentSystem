using System.Threading.Tasks;
using Autofac;
using BuildingBlocks.Application.UseCases;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using MediatR;

namespace IncidentReport.Infrastructure.Configuration.Processing.UseCases
{
    internal class UseCaseExecutor
    {
        internal async static Task<TUseCaseOutput> Execute<TUseCaseOutput>(IUseCaseInput<TUseCaseOutput> useCase) where TUseCaseOutput : IUseCaseOutput
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var _mediator = scope.Resolve<IMediator>();

                return await _mediator.Send(useCase);
            }
        }
    }
}
