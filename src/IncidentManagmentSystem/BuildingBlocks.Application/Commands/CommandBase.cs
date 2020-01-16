using System;
using MediatR;

namespace BuildingBlocks.Application.Commands
{
    public abstract class CommandBase : IRequest
    {
        protected Guid Id { get; }

        protected CommandBase()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
