using Movie.Core.Enums;

namespace Movie.Core.Models;

public class Movie
{
    private Guid Id { get; set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int Year { get; private set; }
    public Genre Genre { get; private set; }
    public string? PosterUrl { get; private set; }

    public ICollection<Review> Reviews { get; private set; }

    private readonly List<Rating> _ratings = [];      

    public IReadOnlyCollection<Rating> Ratings => _ratings.AsReadOnly(); 

    private Movie(Guid id, string title, string description, int year, Genre genre, ICollection<Review> reviews)
    {
        Id = id;
        Title = title;
        Description = description;
        Year = year;
        Genre = genre;
        Reviews = reviews;
    }

    public static Movie Create(string title, string description, int year, Genre genre, ICollection<Review> reviews)
    {
        return new Movie(Guid.NewGuid(), title, description, year, genre, reviews);
    }

    public void AddRating(Rating rating)
    {
        // Проверка, что фильм существует
        if (rating.MovieId != Id)
        {
            throw new ArgumentException("The rating movie ID does not match the current movie.");
        }

        _ratings.Add(rating);
    }

    public double GetAverageRating()
    {
        if (_ratings.Count == 0)
            return 0; 

        return _ratings.Average(r => r.Score); 
    }

    public double GetAverageRatingExcludingUser(Guid userId)
    {
        var ratingsExcludingUser = _ratings.Where(r => r.UserId != userId).ToList();
        if (ratingsExcludingUser.Count == 0)
            return 0;

        return ratingsExcludingUser.Average(r => r.Score); 
    }
}
