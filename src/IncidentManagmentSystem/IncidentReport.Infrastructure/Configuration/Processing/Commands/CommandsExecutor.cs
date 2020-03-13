using System.Threading.Tasks;
using Autofac;
using BuildingBlocks.Application.Commands;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using MediatR;

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

        internal async static Task<ICommandResult> ExecuteWithResult(ICommand<ICommandResult> command)
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var _mediator = scope.Resolve<IMediator>();

                return await _mediator.Send(command);
            }
        }
    }
}
