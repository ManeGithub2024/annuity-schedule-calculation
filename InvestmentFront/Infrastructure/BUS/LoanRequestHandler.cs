using AutoMapper;
using InvestmentFront.Domain.Entities;
using InvestmentFront.Domain.Services;
using InvestmentFront.Models;
using System;

namespace InvestmentFront.Infrastructure.BUS
{
    public class LoanRequestHandler : ICommandHandler<LoanRequestCommand>
    {
        public LoanRequestHandler()
        {
        }

        public IRepository<LoanRequest> _loanRequestRepository { get; }
        public IMapper _mapper { get; }

        public LoanRequestHandler(IRepository<LoanRequest> repository, IMapper mapper)
        {
            _loanRequestRepository = repository;
            _mapper = mapper;
        }

        public ICommandResult Execute(LoanRequestCommand command, ICommandBus bus)
        {
            var request = _mapper.Map<LoanRequest>(command.Source);
            _loanRequestRepository.Create(request);
            var result = bus.Submit<LoanCommand>(new LoanCommand(new LoanRequestInfo { LoanRequestID = request.LoanRequestID }));

            return new CommandResult(result.Success);
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }
    }
}