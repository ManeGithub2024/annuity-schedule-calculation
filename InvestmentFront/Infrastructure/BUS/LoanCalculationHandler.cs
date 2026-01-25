using InvestmentFront.Domain.Entities;
using InvestmentFront.Domain.Services;
using InvestmentFront.Infrastructure.Services;
using System;

namespace InvestmentFront.Infrastructure.BUS
{
    public class LoanCalculationHandler : ICommandHandler<LoanCalculationCommand>
    {
        public IRepository<Loan> _loanRepository { get; }
        public ICalculationService _calculator { get; }

        public LoanCalculationHandler(IRepository<Loan> loanRepository, ICalculationService calculator)
        {
            _loanRepository = loanRepository;
            _calculator = calculator;
        }

        public ICommandResult Execute(LoanCalculationCommand command, ICommandBus bus)
        {
            var loan = _loanRepository.Get(command.Source.LoanID);
            var anuitet = _calculator.CalcAnnuitet(loan.Amount, loan.Product.AnnualRate, loan.Term * 12);
            loan.State = LoanStatus.Accepted;
            loan.CurrentDebt = Math.Round(anuitet.CreditAmount, 2);
            loan.Updated = DateTime.Now;
            loan.AgreementDate = DateTime.Now.Date;
            loan.EndTerm = DateTime.Now.AddMonths(loan.Term * 12);

            return new CommandResult(true);
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }
    }
}