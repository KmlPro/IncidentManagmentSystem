using Autofac;
using BuildingBlocks.Application.Commands;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using MediatR;
using System.Threading.Tasks;

namespace IncidentReport.Infrastructure.Configuration.Processing.Commands
{
    internal class CommandsExecutor
    {
        internal async static Task Execute(ICommand command)
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var _mediator = scope.Resolve<IMediator>();

                await _mediator.Send(command);
            }
        }
    }
}
