namespace InvestmentFront.Infrastructure.BUS
{
    public interface ICommandResult
    {
        bool Success { get; }
        int? Id { get; }
    }

    public interface ICommandResult<out T> : ICommandResult
    {
        T Result { get; }
    }
}
