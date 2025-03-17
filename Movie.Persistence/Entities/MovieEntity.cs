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
    
    public List<RatingEntity> Ratings { get; set; } = [];
    public List<ReviewEntity> Reviews { get; set; } = [];
}