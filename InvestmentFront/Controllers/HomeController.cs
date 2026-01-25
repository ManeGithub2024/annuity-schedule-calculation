using AutoMapper;
using InvestmentFront.Domain.Entities;
using InvestmentFront.Domain.Services;
using InvestmentFront.Infrastructure.Services;
using InvestmentFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvestmentFront.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<Loan> _loanRepository { get; }
        public ICalculationService _calculator { get; }
        public IMapper _mapper { get; }

        public HomeController(IRepository<Loan> loanRepository, ICalculationService calculator, IMapper mapper) {
            _loanRepository = loanRepository;
            _calculator = calculator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var loans = _loanRepository.GetAll();
            var schedules = new List<LoanViewModel>();
            foreach (var item in loans) {
                var schedule = _calculator.PaymentScheduleAnnuitet(item.Amount, item.Product.AnnualRate, item.Term * 12, item.AgreementDate);
                var loan = new LoanViewModel {
                    AgreementNumber = item.AgreementNumber,
                    CreditAmount = item.CurrentDebt,
                    Amount = item.Amount,
                    Schedule = _mapper.Map<IEnumerable<ScheduleViewModel>>(schedule)
                };
                schedules.Add(loan);
            }
            return View(schedules);
        }
    }
}