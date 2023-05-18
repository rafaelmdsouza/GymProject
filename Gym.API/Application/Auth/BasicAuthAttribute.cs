using Microsoft.AspNetCore.Authorization;

namespace Gym.API.Application.Auth
{
    public class BasicAuthAttribute : AuthorizeAttribute
    {
        public BasicAuthAttribute()
        {
            AuthenticationSchemes = BasicAuthDefaults.AuthenticationScheme;
        }
    }
}
