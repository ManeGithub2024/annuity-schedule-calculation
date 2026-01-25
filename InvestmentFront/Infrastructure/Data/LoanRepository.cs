using InvestmentFront.Domain.Entities;
using InvestmentFront.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentFront.Infrastructure.Data
{
    public class LoanRepository : IRepository<Loan>
    {
        static List<Loan> _loans;

        static LoanRepository()
        {
            _loans = new List<Loan>();
        }

        public LoanRepository()
        {
        }
        public Loan Get(int id) => _loans.Find(x => x.LoanID == id);
        public IQueryable<Loan> GetAll() => _loans.AsQueryable();

        public void Create(Loan item)
        {
            item.LoanID = _loans.Any() ? _loans.Max(x => x.LoanID) + 1 : 1;
            _loans.Add(item);
        }
        public void Delete(int id) => throw new NotImplementedException();
        public void Update(Loan item) => throw new NotImplementedException();
    }
}
