namespace Movie.Core.Models;

public class Review
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTime Date { get; private set; }
    
    public Guid MovieId { get; private set; }
    public Movie Movie { get; private set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; private set; }

    private Review(Guid id, string content, DateTime date, string title, Movie movie, User user)
    {
        Id = id;
        Content = content;
        Title = title;
        Movie = movie;
        User = user;
        Date = date;
    }

    public static Review Create(Guid id, string content, DateTime date, string title, Movie movie, User user)
    {
        return new Review(id, content, date, title, movie, user);
    }
}