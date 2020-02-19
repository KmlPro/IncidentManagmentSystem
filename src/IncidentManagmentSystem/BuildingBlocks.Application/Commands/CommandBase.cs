using System;

namespace BuildingBlocks.Application.Commands
{
    public abstract class CommandBase : ICommand
    {
        public Guid Id { get; }

        protected CommandBase()
        {
            this.Id = Guid.NewGuid();
        }
    }

    public abstract class CommandBase<TResult> : ICommand<TResult> where TResult : ICommandResult
    {
        public Guid Id { get; }

        protected CommandBase()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
