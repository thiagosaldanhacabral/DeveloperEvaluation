using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Domain.Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> CreateAsync(Rating rating, CancellationToken cancellationToken = default);

        Task<Rating?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        IQueryable<Rating> GetAllAsync(CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Rating> UpdateAsync(Rating rating, CancellationToken cancellationToken = default);
    }
}
