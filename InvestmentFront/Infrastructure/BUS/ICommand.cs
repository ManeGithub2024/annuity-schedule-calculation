namespace InvestmentFront.Infrastructure.BUS
{
    public interface ICommand
    {

    }

    public interface ICommand<T>
    {
        T Source { get; set; }
    }
}
