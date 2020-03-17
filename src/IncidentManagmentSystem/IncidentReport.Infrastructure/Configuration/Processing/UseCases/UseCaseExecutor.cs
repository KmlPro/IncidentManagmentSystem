using System.Threading.Tasks;
using Autofac;
using BuildingBlocks.Application.UseCases;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using MediatR;

namespace IncidentReport.Infrastructure.Configuration.Processing.UseCases
{
    internal class UseCaseExecutor
    {
        internal async static Task Execute(IUseCaseInput useCase)
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var _mediator = scope.Resolve<IMediator>();

                await _mediator.Send(useCase);
            }
        }
    }
}
