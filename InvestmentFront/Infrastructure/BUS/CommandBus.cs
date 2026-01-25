using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentFront.Infrastructure.BUS
{
    public class CommandBus : ICommandBus
    {
        private readonly IEnumerable<ICommandHandler> _handlers;

        public CommandBus(IEnumerable<ICommandHandler> handlers)
        {
            _handlers = handlers;
        }

        private ICommandHandler<TCommand> GetHandler<TCommand>()
        {
            return (ICommandHandler<TCommand>)_handlers.FirstOrDefault(x => (x as ICommandHandler<TCommand>) != null);
        }

        public ICommandResult Submit<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var handler = GetHandler<TCommand>();

            if (!((handler != null) && handler is ICommandHandler<TCommand>)) {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }
            try {
                return handler.Execute(command, this);
            } catch {
                handler.Rollback();
                throw;
            }
        }

        public ICommandResult<TResult> Submit<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            var handler = GetHandler<TCommand>();

            if (!((handler != null) && handler is ICommandHandler<TCommand>)) {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }
            try {
                return handler.Execute(command, this) as CommandResult<TResult>;
            } catch {
                handler.Rollback();
                throw;
            }
        }

        public ICommandResult Submit<TCommand, TCommandHandler>(TCommand command, TCommandHandler commandHandler)
            where TCommand : ICommand
            where TCommandHandler : ICommandHandler<TCommand>
        {
            if (!((commandHandler != null) && commandHandler is ICommandHandler<TCommand>)) {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }

            try {
                return commandHandler.Execute(command, this);
            } catch {
                commandHandler.Rollback();
                throw;
            }
        }
    }
}
