﻿using DeveloperEvaluation.Domain.Entities;
using DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IUserRepository using Entity Framework Core
/// </summary>
public class RatingRepository : IRatingRepository
{
    private readonly DefaultContext _context;

    public RatingRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Rating> CreateAsync(Rating rating, CancellationToken cancellationToken = default)
    {
        await _context.Ratings.AddAsync(rating, cancellationToken);
        return rating;
    }

    public async Task<Rating?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Ratings.Where(o => o.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public IQueryable<Rating> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _context.Ratings;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var rating = await GetByIdAsync(id, cancellationToken);

        if (rating == null)
            return false;

        _context.Ratings.Remove(rating);
        return true;
    }

    public async Task<Rating> UpdateAsync(Rating rating, CancellationToken cancellationToken = default)
    {
        var existingRating = await _context.Ratings.FindAsync([rating.Id], cancellationToken);

        if (existingRating == null)
            return new Rating { };

        existingRating.Rate = rating.Rate;
        existingRating.Count = rating.Count;

        _context.Ratings.Update(existingRating);

        return existingRating;
    }
}
