using System;

namespace InvestmentFront.Domain.Entities
{
    public class RepaymentRequest
    {
        public int RepaymentRequestID { get; set; }
        public DateTime Created { get; set; }
        public string AgreementNumber { get; set; }
        public string TrnIdentity { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
