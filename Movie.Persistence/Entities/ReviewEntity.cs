

namespace Movie.Persistance.Entities;

public class ReviewEntity(MovieEntity movie)
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    
    public Guid MovieId { get; set; }
    public MovieEntity Movie { get; set; } = null!;
    
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = null!;
}