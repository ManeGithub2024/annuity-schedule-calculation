namespace InvestmentFront.Infrastructure.BUS
{
    public abstract class Command<T> : ICommand, ICommand<T>
    {
        public T Source { get; set; }

        protected Command(T source)
        {
            Source = source;
        }
    }
}
