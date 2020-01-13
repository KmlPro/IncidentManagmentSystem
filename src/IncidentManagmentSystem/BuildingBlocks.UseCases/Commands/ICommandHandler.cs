using MediatR;

namespace BuildingBlocks.UseCases.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : CommandBase
    {
    }
}
