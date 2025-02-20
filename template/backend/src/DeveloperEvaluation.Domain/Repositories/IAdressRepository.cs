using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Domain.Repositories
{
    public interface IAdressRepository
    {
        Task<Address> CreateAsync(Address address, CancellationToken cancellationToken = default);

        Task<Address> UpdateAsync(Address address, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
