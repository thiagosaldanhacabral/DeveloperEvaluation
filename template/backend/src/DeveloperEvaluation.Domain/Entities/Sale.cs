namespace DeveloperEvaluation.Domain.Entities;

public class Sale
{
    public Guid Id { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalValue { get; set; }  
    public bool Canceled { get; set; }  

    public Guid CustomerId { get; set; }
    public User? Customer { get; set; }

    public ICollection<SaleProduct>? SaleProducts { get; set; }
}
