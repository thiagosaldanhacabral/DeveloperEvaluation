using Microsoft.EntityFrameworkCore.Storage;

namespace DeveloperEvaluation.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken);

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}
