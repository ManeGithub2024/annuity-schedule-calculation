using InvestmentFront.Models;

namespace InvestmentFront.Infrastructure.BUS
{
    public class LoanRequestCommand : Command<ProductInfo>
    {
        public LoanRequestCommand(ProductInfo source) : base(source)
        {
        }
    }
}