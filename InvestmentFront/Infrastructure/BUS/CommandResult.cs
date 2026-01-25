namespace InvestmentFront.Infrastructure.BUS
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {
            Success = true;
        }

        public CommandResult(bool success)
        {
            Success = success;
        }

        public CommandResult(bool success, int id)
        {
            Success = success;
            Id = id;
        }

        public bool Success { get; protected set; }
        public int? Id { get; protected set; }
    }

    public class CommandResult<T> : CommandResult, ICommandResult<T>
    {
        public T Result { get; set; }

        public CommandResult(bool success, T result) : base(success)
        {
            Result = result;
        }

        public CommandResult(T result)
            : base(true)
        {
            Result = result;
        }
    }
}
