using System.Threading.Tasks;
using BuildingBlocks.Application.Commands;
using MediatR;

namespace IncidentReport.Infrastructure.Configuration.Processing.Commands
{
    public class CommandsExecutor
    {
        private readonly IMediator _mediator;

        public CommandsExecutor(IMediator mediator)
        {
            this._mediator = mediator;
        }

        internal async Task Execute(ICommand command)
        {
            await this._mediator.Send(command);
        }
    }
}
