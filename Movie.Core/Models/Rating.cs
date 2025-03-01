namespace Movie.Core.Models;
public class Rating
{
    public Guid Id { get; private set; }
    public Guid MovieId { get; set; }
    public Guid UserId { get; set; }
    public int Score { get; private set; }

    private Rating(Guid movieId, Guid userId, int score)
    {
        Id = Guid.NewGuid();
        MovieId = movieId;
        UserId = userId;
        SetRating(score);
    }

    private void SetRating(int score)
    {
        if (score is < 1 or > 10)
        {
            throw new ArgumentException("Rating must be between 1 and 10.");
        }
        Score = score;
    }

    public static Rating Create(Guid movieId, Guid userId, int score)
    {
        return new Rating(movieId, userId, score);
    }
}
