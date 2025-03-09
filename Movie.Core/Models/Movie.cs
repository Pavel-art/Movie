using Movie.Core.Enums;

namespace Movie.Core.Models;

public class Movie
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int Year { get; private set; }
    public Genre Genre { get; private set; }
    public string? PosterUrl { get; private set; }

    private readonly List<Rating> _ratings = [];
    private readonly List<Review> _reviews = [];

    public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();
    public IReadOnlyCollection<Rating> Ratings => _ratings.AsReadOnly();

    private Movie(Guid id, string title, string description, int year, Genre genre, string posterUrl)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Year = year;
        Genre = genre;
    }

    public static Movie Create(string title, string description, int year, Genre genre, string posterUrl)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        if (title.Length > 200)
            throw new ArgumentException("Title must be less than 200 characters.", nameof(title));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));

        if (year < 1888 || year > DateTime.UtcNow.Year)
            throw new ArgumentOutOfRangeException(nameof(year), "Year must be valid.");

        if (!Enum.IsDefined(typeof(Genre), genre))
            throw new ArgumentException("Invalid genre.", nameof(genre));

        if (string.IsNullOrWhiteSpace(posterUrl) || !Uri.TryCreate(posterUrl, UriKind.Absolute, out _))
            throw new ArgumentException("Poster URL must be a valid absolute URL.", nameof(posterUrl));

        return new Movie(Guid.NewGuid(), title, description, year, genre, posterUrl);
    }

    public void AddReview(string title, string content)
    {
        var review = Review.Create(content, title);
        _reviews.Add(review);
    }


    public void AddRating(Guid userId, int score)
    {
        var rating = Rating.Create(Guid.NewGuid(), userId, score);
        _ratings.Add(rating);
    }

    public double GetAverageRating() => _ratings.Count == 0 ? 0 : _ratings.Average(r => r.Score);

    public void UpdateTitle(string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("Title cannot be empty.", nameof(newTitle));

        if (newTitle.Length > 200)
            throw new ArgumentException("Title must be less than 200 characters.", nameof(newTitle));

        Title = newTitle;
    }

    public void UpdateDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
            throw new ArgumentException("Description cannot be empty.", nameof(newDescription));

        Description = newDescription;
    }

    public void UpdateGenre(Genre newGenre)
    {
        if (!Enum.IsDefined(typeof(Genre), newGenre))
            throw new ArgumentException("Invalid genre.", nameof(newGenre));
        Genre = newGenre;
    }

    public void UpdatePosterUrl(string newUrl)
    {
        if (string.IsNullOrWhiteSpace(newUrl) || !Uri.TryCreate(newUrl, UriKind.Absolute, out _))
            throw new ArgumentException("Poster URL must be a valid absolute URL.", nameof(newUrl));
        
        PosterUrl = newUrl;
    }
}