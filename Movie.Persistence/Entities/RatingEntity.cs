

namespace Movie.Persistance.Entities;

public class RatingEntity
{
    public Guid Id { get; set; }
    public int Score { get; set; }
    
    public Guid MovieId { get; set; }
    public MovieEntity Movie { get; set; } = null!; 
    
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = null!;
}