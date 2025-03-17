namespace Movie.Core.Models;

public class RatingModel
{
    public Guid Id { get; private set; }
    public int Score { get; private set; }

    private RatingModel(int score)
    {
        Id = Guid.NewGuid();
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

    public static RatingModel Create(Guid movieId, Guid userId, int score)
    {
        if (score is < 0 or > 10)
            throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 0 and 10.");

        return new RatingModel(score);
    }
}