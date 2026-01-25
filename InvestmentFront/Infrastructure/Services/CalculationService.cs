using InvestmentFront.Infrastructure.Services.Model;
using System;
using System.Collections.Generic;

namespace InvestmentFront.Infrastructure.Services
{
    public class CalculationService : ICalculationService
    {
        public AnnuitetDto CalcAnnuitet(double sumCredit, double interestRateYear, int creditPeriod)
        {
            var interestRateMonth = interestRateYear / 100 / 12;
            var payment = sumCredit * (interestRateMonth / (1 - Math.Pow(1 + interestRateMonth, -creditPeriod)));
            var itogCreditSum = payment * creditPeriod;

            return new AnnuitetDto {
                CreditAmount = itogCreditSum,
                MonthlyPayment = payment,
                MonthlyInterestRate = interestRateMonth,
                Amount = sumCredit,
                InterestRateYear = interestRateYear,
                Term = creditPeriod
            };
        }

        public IEnumerable<ScheduleDto> PaymentScheduleAnnuitet(double sumCredit, double interestRateYear, int creditPeriod, DateTime? calcDate = null)
        {
            var interestRateMonth = interestRateYear / 100 / 12;
            var payment = sumCredit * (interestRateMonth / (1 - Math.Pow(1 + interestRateMonth, -creditPeriod)));
            var itogCreditSum = payment * creditPeriod;

            var schedule = new List<ScheduleDto>();
            var date = calcDate ?? DateTime.Now;
            var sumCreditOperation = sumCredit;
            var itogPlus = 0.0;
            for (int i = 0; i < creditPeriod; ++i) {
                double procent = sumCreditOperation * (interestRateYear / 100) / 12;
                sumCreditOperation -= payment - procent;
                itogPlus = sumCreditOperation;
                var item = new ScheduleDto {
                    Id = i + 1,
                    Payment = payment,
                    Body = payment - procent,
                    Percent = procent,
                    Left = sumCreditOperation,
                    PaymentDate = date.AddMonths(i + 1)
                };
                schedule.Add(item);
            }
            return schedule;
        }
    }
}
