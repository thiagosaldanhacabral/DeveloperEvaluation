using DeveloperEvaluation.Domain.Entities;
using DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeveloperEvaluation.ORM.Repositories
{
    public class SaleProductRepository : ISaleProductRepository
    {
        private readonly DefaultContext _context;

        public SaleProductRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<SaleProduct?> GetByIdAsync(Guid saleId, Guid productId)
        {
            return await _context.SaleProducts
                .Include(vp => vp.Sale)
                .Include(vp => vp.Product)
                .FirstOrDefaultAsync(vp => vp.SaleId == saleId && vp.ProductId == productId);
        }


        public async Task<IEnumerable<SaleProduct>> GetSaleIdAsync(Guid saleId)
        {
            return await _context.SaleProducts
                .Where(vp => vp.SaleId == saleId)
                .Include(vp => vp.Product)
                .ToListAsync();
        }

        public async Task AddAsync(SaleProduct saleProduct)
        {
            await _context.SaleProducts.AddAsync(saleProduct);
            await SaveAsync();
        }


        public async Task UpdateAsync(SaleProduct saleProduct)
        {
            _context.SaleProducts.Update(saleProduct);
            await SaveAsync();
        }


        public async Task DeleteAsync(Guid saleId, Guid productId)
        {
            var saleProduct = await GetByIdAsync(saleId, productId);

            if (saleProduct != null)
            {
                _context.SaleProducts.Remove(saleProduct);
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
