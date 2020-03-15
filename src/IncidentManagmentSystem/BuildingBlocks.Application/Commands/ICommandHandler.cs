using MediatR;

namespace BuildingBlocks.Application.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : CommandBase
    {
    }

    public interface ICommandHandlerWithResult<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
                                                                             where TCommand : ICommand<TResponse>
                                                                             where TResponse : ICommandResult
    {
    }
}
