using AutoMapper;
using InvestmentFront.Domain.Entities;
using InvestmentFront.Domain.Services;
using InvestmentFront.Infrastructure.BusinessLogic;
using InvestmentFront.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentFront.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        public IRepository<Product> _productRepository { get; }
        public IRangeCalculator _rangeCalculator { get; }
        public IMapper _mapper { get; }

        public ProductService(IRepository<Product> productRepository, IRangeCalculator rangeCalculator, IMapper mapper)
        {
            _productRepository = productRepository;
            _rangeCalculator = rangeCalculator;
            _mapper = mapper;
        }

        public IEnumerable<ProductInfo> GetProducts()
        {
            var repoProducts = _productRepository.GetAll();
            var products = _mapper.Map<IEnumerable<ProductInfo>>(repoProducts);
            return PrepareTermsAndAmounts(products);
        }

        private IEnumerable<ProductInfo> PrepareTermsAndAmounts(IEnumerable<ProductInfo> products)
        {
            foreach (var item in products) {
                List<SelectListItem> terms = _rangeCalculator.GetValues(item.MinTerm, item.MaxTerm, 1)
                    .Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString() }).ToList();
                item.Terms = terms;

                List<SelectListItem> amounts = _rangeCalculator.GetValues(item.MinAmount, item.MaxAmount, item.AmountStep)
                    .Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString() }).ToList();
                item.Amounts = amounts;
            }

            return products;
        }
    }
}
