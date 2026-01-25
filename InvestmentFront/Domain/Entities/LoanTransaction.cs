using System;

namespace InvestmentFront.Domain.Entities
{
    public class LoanTransaction
    {
        public int LoanTransactionID { get; set; }
        public int? RepaymentRequestID { get; set; }
        public DateTime Created { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
    }
}
