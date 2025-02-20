using DeveloperEvaluation.Domain.Entities;
using DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeveloperEvaluation.ORM.Repositories
{

    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task<Sale> GetSaleAsync(Guid saleId)
        {
            var sale = await _context.Sales
                                     .Include(v => v.SaleProducts!)
                                     .ThenInclude(iv => iv.Product)
                                     .FirstOrDefaultAsync(v => v.Id == saleId) ?? throw new KeyNotFoundException($"Sale with ID {saleId} not found.");
            return sale;
        }

        public async Task<Sale> UpdateSaleAsync(Guid saleId, Sale sale)
        {
            var existingSale = await _context.Sales.Include(v => v.SaleProducts)
                                                       .FirstOrDefaultAsync(v => v.Id == saleId) ?? throw new KeyNotFoundException($"Not possible refresh sale. Because not foun sale for {saleId.ToString()}");
            existingSale.CustomerId = sale.CustomerId;
            existingSale.SaleProducts = sale.SaleProducts;

            existingSale.TotalValue = sale.TotalValue;

            _context.Sales.Update(existingSale);
            await _context.SaveChangesAsync();

            return existingSale;
        }

        public async Task<bool> CancelSaleAsync(Guid saleId)
        {
            var sale = await _context.Sales.Include(v => v.SaleProducts)
                                               .FirstOrDefaultAsync(v => v.Id == saleId) ?? throw new KeyNotFoundException("Not possible remove sale. Because not found sale");
            sale.Canceled = true;
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CancelItemAsync(Guid saleId, Guid itemId)
        {
            var itemSale = await _context.SaleProducts
                                            .FirstOrDefaultAsync(iv => iv.SaleId == saleId && iv.SaleId == itemId) ?? throw new KeyNotFoundException("Item not found");
            itemSale.Discount = 0;
            itemSale.TotalValue = 0;

            _context.SaleProducts.Update(itemSale);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
