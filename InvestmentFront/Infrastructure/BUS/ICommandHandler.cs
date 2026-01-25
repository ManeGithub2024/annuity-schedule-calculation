namespace InvestmentFront.Infrastructure.BUS
{
    public interface ICommandHandler<in TCommand> : ICommandHandler
    {
        ICommandResult Execute(TCommand command, ICommandBus bus);
    }

    public interface ICommandHandler
    {
        void Rollback();
    }
}
