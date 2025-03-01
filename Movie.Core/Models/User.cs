using Movie.Core.Enums;

namespace Movie.Core.Models;

public class User
{
    private Guid Id { get; set; }
    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public string Email { get; private set; }
    public Role Role { get; private set; }
    private ICollection<Rating> Ratings { get; set; }
    public ICollection<Review> Reviews { get; private set; }

    private User(Guid id, string userName, string passwordHash, string email, Role role)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
        Email = email;
        Role = role;
        Ratings = new List<Rating>();  
        Reviews = new List<Review>();  
    }

    public static User Create(Guid id, string userName, string passwordHash, string email, Role role)
    {
        return new User(id, userName, passwordHash, email, role);
    }

    public void AddRating(Rating rating)
    {
        Ratings.Add(rating);
    }
}
