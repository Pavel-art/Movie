using Movie.Core.Enums;

namespace Movie.Persistance.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Role Role { get; set; }
    
    public List<RatingEntity> Ratings { get; set; } = [];
    public List<ReviewEntity> Reviews { get; set; } = [];
    
}