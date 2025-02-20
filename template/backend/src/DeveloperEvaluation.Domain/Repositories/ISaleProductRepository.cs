using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleProductRepository
    {
        Task<SaleProduct?> GetByIdAsync(Guid saleID, Guid productId);
        Task<IEnumerable<SaleProduct>> GetSaleIdAsync(Guid SaleId);
        Task AddAsync(SaleProduct saleProduct);
        Task UpdateAsync(SaleProduct saleProduct);
        Task DeleteAsync(Guid SaleId, Guid ProductId);
        Task SaveAsync();
    }

}
