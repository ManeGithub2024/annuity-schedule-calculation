using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InvestmentFront.Models
{
    public class LoanViewModel
    {
        public string AgreementNumber { get; set; }
        public double CreditAmount { get; set; }
        public double Amount { get; set; }
        public IEnumerable<ScheduleViewModel> Schedule { get; set; }
    }
}
