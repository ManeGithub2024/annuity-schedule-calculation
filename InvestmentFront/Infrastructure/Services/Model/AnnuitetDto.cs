using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentFront.Infrastructure.Services.Model
{
    public class AnnuitetDto
    {
        public double MonthlyInterestRate { get; set; }
        public double MonthlyPayment { get; set; }
        public double CreditAmount { get; set; }
        public double Amount { get; set; }
        public double InterestRateYear { get; set; }
        public int Term { get; set; }
    }
}
