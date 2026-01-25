using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InvestmentFront.Models
{
    public class ProductInfo
    {
        public ProductInfo()
        {
            Amounts = new List<SelectListItem>();
            Terms = new List<SelectListItem>();
        }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { set; get; }
        public decimal AnnualRate { get; set; }
        public decimal Amount { get; set; }
        public List<SelectListItem> Amounts { get; set; }
        public int Term { get; set; }
        public List<SelectListItem> Terms { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int AmountStep { get; set; }
        public int MinTerm { get; set; }
        public int MaxTerm { get; set; }
    }
}
