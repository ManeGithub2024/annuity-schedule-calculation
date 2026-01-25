using InvestmentFront.Domain.Entities;
using InvestmentFront.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentFront.Infrastructure.Data
{
    public class LoanRequestRepository : IRepository<LoanRequest>
    {
        static List<LoanRequest> _request;

        static LoanRequestRepository()
        {
            _request = new List<LoanRequest>();
        }

        public LoanRequestRepository()
        {
        }

        public LoanRequest Get(int id) => _request.Find(x => x.LoanRequestID == id);

        public IQueryable<LoanRequest> GetAll() => _request.AsQueryable();

        public void Create(LoanRequest item)
        {
            item.LoanRequestID = _request.Any() ? _request.Max(x => x.LoanRequestID) + 1 : 1;
            _request.Add(item);
        }

        public void Delete(int id) => throw new NotImplementedException();
        public void Update(LoanRequest item) => throw new NotImplementedException();
    }
}
