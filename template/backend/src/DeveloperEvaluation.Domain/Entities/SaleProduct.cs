namespace DeveloperEvaluation.Domain.Entities
{

    public class SaleProduct
    {
        public Guid SaleId { get; set; }
        public Sale? Sale { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalValue { get; set; }
    }

}
