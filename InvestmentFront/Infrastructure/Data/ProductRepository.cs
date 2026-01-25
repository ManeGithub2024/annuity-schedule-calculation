using InvestmentFront.Domain.Entities;
using InvestmentFront.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentFront.Infrastructure.Data
{
    public class ProductRepository : IRepository<Product>
    {
        static List<Product> _products;

        static ProductRepository()
        {
            _products = new List<Product>() {
                new Product {ProductID = 1,
                    Name = "Invest_A",
                    Description = "Low",
                    Category ="White",
                    AnnualRate = 14.90,
                    MinAmount = 400000,
                    MaxAmount = 600000,
                    AmountStep = 50000,
                    MinTerm = 1,
                    MaxTerm = 2 }
            };
        }

        public ProductRepository()
        {
        }
        public Product Get(int id) => _products.Find(x => x.ProductID == id);
        public IQueryable<Product> GetAll() => _products.AsQueryable();

        public void Create(Product item) => throw new NotImplementedException();
        public void Delete(int id) => throw new NotImplementedException();
        public void Update(Product item) => throw new NotImplementedException();
    }
}
