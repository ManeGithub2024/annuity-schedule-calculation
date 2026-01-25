using InvestmentFront.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentFront.Controllers
{
    public class ProductController : Controller
    {
        public IProductService _productService{ get; }

        public ProductController(IProductService productService) {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts() {
            var products = _productService.GetProducts();
            return View(products);
        }
    }
}