namespace Gym.Infrastructure.Authentication.Identity;

public class User
{
    private User()
    {
    }

    public User(string username, string password, string role)
    {
        Id = Guid.NewGuid();
        Username = username;
        Password = password;
        Role = role;
    }
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }
}