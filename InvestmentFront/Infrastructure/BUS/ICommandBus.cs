namespace InvestmentFront.Infrastructure.BUS
{
    public interface ICommandBus
    {
        ICommandResult Submit<TCommand>(TCommand command)
            where TCommand : ICommand;

        ICommandResult<TResult> Submit<TCommand, TResult>(TCommand command)
            where TCommand : ICommand;

        ICommandResult Submit<TCommand, TCommandHandler>(TCommand command, TCommandHandler commandHandler)
            where TCommand : ICommand
            where TCommandHandler : ICommandHandler<TCommand>;
    }
}
