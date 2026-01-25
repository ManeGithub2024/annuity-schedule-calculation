using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestmentFront.Domain.Entities;
using InvestmentFront.Domain.Services;
using InvestmentFront.Infrastructure.BUS;
using InvestmentFront.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentFront.Controllers
{
    public class LoanController : Controller
    {
        public IRepository<LoanRequest> _loanRequestRepository { get; }
        public ICommandBus _commandBus { get; }

        public LoanController(IRepository<LoanRequest> loanRequestRepository, ICommandBus commandBus) {
            _loanRequestRepository = loanRequestRepository;
            _commandBus = commandBus;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetLoans() {
            var requests = _loanRequestRepository.GetAll();
            return View("", requests);
        }

        [HttpPost]
        public IActionResult AddLoanRequest(ProductInfo request) {

            var result = _commandBus.Submit<LoanRequestCommand>(new LoanRequestCommand(request));
            if (result.Success) {
                return RedirectToAction("Index", "Home");
            }

            var requests = _loanRequestRepository.GetAll();
            return View("", requests);
        }
    }
}