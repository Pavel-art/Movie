using Movie.Core.Models;

namespace Movie.Core.Repositories;

public interface IMovieRepository
{
    Task<List<MovieModel>> GetAllAsync(CancellationToken cancellationToken);
    Task<MovieModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Guid> AddAsync(MovieModel movie, CancellationToken cancellationToken);
    Task<Guid> UpdateAsync(MovieModel movie, CancellationToken cancellationToken);
    Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken);
};