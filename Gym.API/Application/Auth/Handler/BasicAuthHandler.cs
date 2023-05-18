using Gym.API.Application.Auth.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Gym.API.Application.Auth.Handler
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing auth key"));
            }

            var authHeader = Request.Headers["Authorization"].ToString();

            if (!authHeader.StartsWith("Basic", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid auth headers type"));
            }

            var authBase64Decoded = Encoding.UTF8.GetString(
                Convert.FromBase64String(
                    authHeader.Replace("Basic", "", StringComparison.OrdinalIgnoreCase)
                    )
                );

            var authSplit = authBase64Decoded.Split(new[] { ':' }, 2);
            if(authSplit.Length != 2) 
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid auth headers format"));
            }

            var clientId = authSplit[0];
            var clientSecret = authSplit[1];

            if(clientId != "admin" || clientSecret != "admin")
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid login or password"));
            }

            var client = new BasicAuthClient
            {
                AuthenticationType = BasicAuthDefaults.AuthenticationScheme,
                IsAuthenticated = true,
                Name = clientId
            };

            var claims = new ClaimsPrincipal(new ClaimsIdentity(client, new[]
            {
                new Claim(ClaimTypes.Name, clientId)
            }));

            return Task.FromResult(
                AuthenticateResult.Success(
                    new AuthenticationTicket(claims, Scheme.Name)
                    ));

        }
    }
}
