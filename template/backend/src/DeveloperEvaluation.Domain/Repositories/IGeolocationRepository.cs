using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Domain.Repositories
{
    public interface IGeolocationRepository
    {
        Task<Geolocation> CreateAsync(Geolocation geolocation, CancellationToken cancellationToken = default);

        Task<Geolocation> UpdateAsync(Geolocation geolocation, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
