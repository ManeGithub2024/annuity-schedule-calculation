using InvestmentFront.Models;
using System.Collections.Generic;

namespace InvestmentFront.Infrastructure.Services
{
    public interface IProductService
    {
        IEnumerable<ProductInfo> GetProducts();
    }
}
