using Movie.Core.Models;

namespace Movie.Core.Repositories;

public interface IUserRepository
{
    Task<UserModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<UserModel?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<Guid> AddAsync(UserModel user, CancellationToken cancellationToken);
    Task<Guid> UpdateAsync(UserModel user, CancellationToken cancellationToken);
    Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken);
}