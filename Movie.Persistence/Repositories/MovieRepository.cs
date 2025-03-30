using Microsoft.EntityFrameworkCore;
using Movie.Core.Models;
using Movie.Core.Repositories;
using Movie.Persistance.Entities;

namespace Movie.Persistance.Repositories;

public class MovieRepository(MovieDbContext context) : IMovieRepository
{
    public async Task<List<MovieModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await context.Movies
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var movieModels = entities.Select(e => MovieModel.Create(
            title: e.Title,
            description: e.Description,
            year: e.Year,
            genre: e.Genre,
            posterUrl: e.PosterUrl ?? ""
        )).ToList();

        return movieModels;
    }

    public async Task<MovieModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await context.Movies
            .AsNoTracking()
            . FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        
        if (entity != null)
        {
            return
                MovieModel.Create(
                    title: entity.Title,
                    description: entity.Description,
                    year: entity.Year,
                    genre: entity.Genre,
                    posterUrl: entity.PosterUrl ?? ""
                );
        }

        return null;
    }

    public async Task<Guid> AddAsync(MovieModel movie, CancellationToken cancellationToken)
    {
        var entity = new MovieEntity
        {
            Title = movie.Title,
            Description = movie.Description,
            Year = movie.Year,
            Genre = movie.Genre,
            PosterUrl = movie.PosterUrl ?? ""
        };
              context.Movies.Add(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<Guid> UpdateAsync(MovieModel movie, CancellationToken cancellationToken)
    {
        var affectedRows = await context.Movies.Where(m => m.Id == movie.Id).ExecuteUpdateAsync(m => m
                .SetProperty(p => p.Title, movie.Title)
                .SetProperty(p => p.Description, movie.Description)
                .SetProperty(p => p.Year, movie.Year)
                .SetProperty(p => p.Genre, movie.Genre)
                .SetProperty(p => p.PosterUrl, movie.PosterUrl)
            , cancellationToken);

        if (affectedRows == 0)
            throw new KeyNotFoundException($"Movie with ID {movie.Id} not found.");
        
        return movie.Id;
    }

    public async Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var affectedRows = await  context.Movies.Where(m => m.Id == id).ExecuteDeleteAsync(cancellationToken);
        if (affectedRows == 0)
            throw new KeyNotFoundException($"Movie with ID {id} not found.");
        return id;
    }
}