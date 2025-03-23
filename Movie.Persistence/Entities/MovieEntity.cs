using Movie.Core.Enums;


namespace Movie.Persistance.Entities;

public class MovieEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Year { get; set; }
    public Genre Genre { get; set; }
    public string? PosterUrl { get; set; }
    
    public ICollection<RatingEntity>  Ratings { get; set; } = [];
    public ICollection<ReviewEntity> Reviews { get; set; } = [];
}