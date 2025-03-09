using ArgumentException = System.ArgumentException;

namespace Movie.Core.Models;

public class Review
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }

    public DateTime Date { get; private set; }

    private Review(string title, string content)
    {
        Id = Guid.NewGuid();
        Content = content;
        Title = title;
        Date = DateTime.UtcNow;
    }

    public static Review Create(string content, string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Content cannot be empty.", nameof(content));

        return new Review(title, content);
    }
}