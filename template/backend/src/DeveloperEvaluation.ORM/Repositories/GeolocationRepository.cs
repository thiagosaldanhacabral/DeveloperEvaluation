using DeveloperEvaluation.Domain.Entities;
using DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeveloperEvaluation.ORM.Repositories
{
    public class GeolocationRepository : IGeolocationRepository
    {
        private readonly DefaultContext _context;

        public GeolocationRepository(DefaultContext context) { _context = context; }


        public async Task<Geolocation> CreateAsync(Geolocation geolocation, CancellationToken cancellationToken = default)
        {
            await _context.Geolocation.AddAsync(geolocation, cancellationToken);
            return geolocation;
        }

        public async Task<Geolocation> UpdateAsync(Geolocation geolocation, CancellationToken cancellationToken = default)
        {
            var existingGeolocation = await _context.Geolocation.FindAsync([geolocation.Id], cancellationToken);

            if (existingGeolocation == null)
            {
                return new Geolocation { };
            }

            existingGeolocation.Lat = geolocation.Lat;
            existingGeolocation.Long = geolocation.Long;

            _context.Geolocation.Update(existingGeolocation);

            return existingGeolocation;
        }

        public async Task<Geolocation?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Geolocation.Where(o => o.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var ads = await GetByIdAsync(id, cancellationToken);

            if (ads == null)
                return false;

            _context.Geolocation.Remove(ads);
            return true;
        }
    }
}
