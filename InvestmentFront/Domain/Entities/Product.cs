namespace InvestmentFront.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { set; get; }
        public double AnnualRate { get; set; }
        public double MinAmount { get; set; }
        public double MaxAmount { get; set; }
        public int AmountStep { get; set; }
        public int MinTerm { get; set; }
        public int MaxTerm { get; set; }
    }
}
