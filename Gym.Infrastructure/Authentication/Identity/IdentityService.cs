using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Gym.Infrastructure.Authentication.Identity;

public class IdentityService
{
    //STATIC LIST
    public static User Login(string username, string password)
    {
        var users = new List<User>();
        users.Add(new User("batman", "batman", Permissions.Role.Admin));
        users.Add(new User("robin", "robin", Permissions.Role.Employee));
        return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
    }

    public static string GenerateToken(User user)
    {
        var tokenSecret = "keytest#mykey@tested!";
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(tokenSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = "https://gym.com",
            Issuer= "https://id.gym.com"
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}