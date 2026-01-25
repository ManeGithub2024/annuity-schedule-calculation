using InvestmentFront.Infrastructure.Services.Model;
using System;
using System.Collections.Generic;

namespace InvestmentFront.Infrastructure.Services
{
    public interface ICalculationService
    {
        AnnuitetDto CalcAnnuitet(double amount, double interestRateYear, int term);
        IEnumerable<ScheduleDto> PaymentScheduleAnnuitet(double SumCredit, double InterestRateYear, int CreditPeriod, DateTime? calcDate = null);
    }
}
