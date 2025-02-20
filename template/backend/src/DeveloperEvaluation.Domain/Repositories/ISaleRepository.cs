using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> CreateSaleAsync(Sale sale);

        Task<Sale> GetSaleAsync(Guid SaleId);

        Task<Sale> UpdateSaleAsync(Guid SaleId, Sale sale);

        Task<bool> CancelSaleAsync(Guid SaleId);

        Task<bool> CancelItemAsync(Guid SaleId, Guid itemId);
    }
}
