using System;

namespace InvestmentFront.Domain.Entities
{
    public class Loan
    {
        public int LoanID { get; set; }
        public int LoanRequestID { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? AgreementDate { get; set; }
        public string AgreementNumber { get; set; }
        public LoanStatus State { get; set; }
        public int Term { get; set; }
        public double Amount { get; set; }
        public double EndTermAmount { get; set; }
        public double CurrentDebt { get; set; }
        public DateTime EndTerm { get; set; }
        public Product Product { get; set; }
    }
}
