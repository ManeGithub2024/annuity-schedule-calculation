using System;

namespace InvestmentFront.Domain.Entities
{
    public class LoanRequest
    {
        public int LoanRequestID { get; set; }
        public DateTime Created { get; set; }
        public decimal Amount { get; set; }
        public int Term { get; set; }
        public int ProductID { get; set; }
        public DateTime? Processed { get; set; }
    }
}
