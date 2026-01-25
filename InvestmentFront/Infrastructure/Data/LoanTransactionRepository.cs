using InvestmentFront.Domain.Entities;
using InvestmentFront.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentFront.Infrastructure.Data
{
    public class LoanTransactionRepository : IRepository<LoanTransaction>
    {
        static List<LoanTransaction> _products;

        static LoanTransactionRepository()
        {
            _products = new List<LoanTransaction>();
        }

        public LoanTransactionRepository()
        {
        }
        public LoanTransaction Get(int id) => _products.Find(x => x.LoanTransactionID == id);
        public IQueryable<LoanTransaction> GetAll() => _products.AsQueryable();

        public void Create(LoanTransaction item) => throw new NotImplementedException();
        public void Delete(int id) => throw new NotImplementedException();
        public void Update(LoanTransaction item) => throw new NotImplementedException();
    }
}
