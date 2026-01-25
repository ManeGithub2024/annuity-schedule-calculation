using InvestmentFront.Models;

namespace InvestmentFront.Infrastructure.BUS
{
    public class LoanCalculationCommand : Command<LoanInfo>
    {
        public LoanCalculationCommand(LoanInfo source) : base(source)
        {
        }
    }
}