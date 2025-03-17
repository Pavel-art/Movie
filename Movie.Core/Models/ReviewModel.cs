using ArgumentException = System.ArgumentException;

namespace Movie.Core.Models;

public class ReviewModel
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTime Date { get; private set; }

    private ReviewModel(string title, string content)
    {
        Id = Guid.NewGuid();
        Content = content;
        Title = title;
        Date = DateTime.UtcNow;
    }

    public static ReviewModel Create(string content, string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Content cannot be empty.", nameof(content));

        return new ReviewModel(title, content);
    }
}