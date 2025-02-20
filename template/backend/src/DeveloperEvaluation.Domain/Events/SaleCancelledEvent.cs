using DeveloperEvaluation.Domain.Dto;

namespace DeveloperEvaluation.Domain.Events
{
    public class SaleCancelledEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public Guid? BranchId { get; }
        public decimal TotalAmount { get; }
        public DateTime SaleDate { get; }

        public List<SaleItemDto> Items { get; }

        public string Message { get; }

        // Construtor
        public SaleCancelledEvent(Guid id, Guid customerId, Guid? branchId, decimal totalAmount, DateTime saleDate, List<SaleItemDto> items, string Message)
        {
            Id = id;
            CustomerId = customerId;
            BranchId = branchId;
            TotalAmount = totalAmount;
            SaleDate = saleDate;
            Items = items;
            Message = Message;
        }
    }

}
