﻿namespace DeveloperEvaluation.Domain.Dto
{
    public class GetSaleDto
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public Guid? BranchId { get; }
        public decimal TotalAmount { get; }
        public DateTime SaleDate { get; }

        public List<SaleItemDto> Items { get; }

        // Construtor
        public GetSaleDto(Guid id, Guid customerId, Guid? branchId, decimal totalAmount, DateTime saleDate, List<SaleItemDto> items)
        {
            Id = id;
            CustomerId = customerId;
            BranchId = branchId;
            TotalAmount = totalAmount;
            SaleDate = saleDate;
            Items = items;
        }
    }

}
