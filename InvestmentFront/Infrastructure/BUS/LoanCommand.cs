using InvestmentFront.Models;

namespace InvestmentFront.Infrastructure.BUS
{
    public class LoanCommand : Command<LoanRequestInfo>
    {
        public LoanCommand(LoanRequestInfo source) : base(source)
        {
        }
    }
}