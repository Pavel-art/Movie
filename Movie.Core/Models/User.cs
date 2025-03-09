using Movie.Core.Enums;

namespace Movie.Core.Models;

public class User
{
    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public string Email { get; private set; }
    public Role Role { get; private set; }

    private User(Guid id, string userName, string passwordHash, string email, Role role)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
        Email = email;
        Role = role;
    }

    public static User Create(Guid id, string userName, string passwordHash, string email, Role role)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("User id cannot be empty.", nameof(id));

        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("User name cannot be empty.", nameof(userName));

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password hash cannot be empty.", nameof(passwordHash));

        if (!Enum.IsDefined(typeof(Role), role))
            throw new ArgumentException("Invalid role specified.", nameof(role));

        if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            throw new ArgumentException("Invalid email format.", nameof(email));

        return new User(id, userName, passwordHash, email, role);
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}