﻿using DeveloperEvaluation.Domain.Dto;

namespace DeveloperEvaluation.Domain.Events
{
    public class SaleModifiedEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public Guid? BranchId { get; }
        public decimal TotalAmount { get; }
        public DateTime SaleDate { get; }

        public List<SaleItemDto> Items { get; }

        // Construtor
        public SaleModifiedEvent(Guid id, Guid customerId, Guid? branchId, decimal totalAmount, DateTime saleDate, List<SaleItemDto> items)
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
