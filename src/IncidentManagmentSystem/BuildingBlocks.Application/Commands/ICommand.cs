using System;
using MediatR;

namespace BuildingBlocks.Application.Commands
{
    public interface ICommand<out TResult> : IRequest<TResult> where TResult : ICommandResult
    {
        Guid Id { get; }
    }

    public interface ICommand : IRequest
    {
        Guid Id { get; }
    }
}
