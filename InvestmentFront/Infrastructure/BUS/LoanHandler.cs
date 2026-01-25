using AutoMapper;
using InvestmentFront.Domain.Entities;
using InvestmentFront.Domain.Services;
using InvestmentFront.Models;
using System;

namespace InvestmentFront.Infrastructure.BUS
{
    public class LoanHandler : ICommandHandler<LoanCommand>
    {
        public IRepository<LoanRequest> _loanRequestRepository { get; }
        public IRepository<Loan> _loanRepository { get; }
        public IRepository<Product> _productRepository { get; }
        public IMapper _mapper { get; }

        public LoanHandler(IRepository<LoanRequest> repository,
            IRepository<Loan> loanRepository,
            IRepository<Product> productRepository,
            IMapper mapper)
        {
            _loanRequestRepository = repository;
            _loanRepository = loanRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ICommandResult Execute(LoanCommand command, ICommandBus bus)
        {
            var request = _loanRequestRepository.Get(command.Source.LoanRequestID);
            var loan = _mapper.Map<Loan>(request);
            var product = _productRepository.Get(request.ProductID);

            request.Processed = DateTime.Now;

            loan.Updated = DateTime.Now;
            loan.AgreementNumber = Guid.NewGuid().ToString();
            loan.State = LoanStatus.Created;
            loan.Product = product;
            _loanRepository.Create(loan);

            var result = bus.Submit<LoanCalculationCommand>(new LoanCalculationCommand(new LoanInfo { LoanID = loan.LoanID }));
            return new CommandResult(result.Success);
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }
    }
}