using Binder.Api.Authentication.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Binder.Api.Authentication
{
    public sealed class GitHubAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IGitHubAuthProvider _provider;

        public GitHubAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IGitHubAuthProvider provider)
            : base(options, logger, encoder, clock)
        {
            _provider = provider;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (_provider.IsAuthenticated())
            {
                ClaimsIdentity identity = new ClaimsIdentity("github");
                identity.AddClaim(new Claim(ClaimTypes.Name, "ok"));
                var principal = new ClaimsPrincipal();
                AuthenticationTicket ticket = new(principal, "github");

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
            else
                return Task.FromResult(AuthenticateResult.Fail("unauth"));
        }
    }
}