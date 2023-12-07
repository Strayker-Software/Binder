using Binder.Api.Authentication.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
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
            _provider.GetCurrentUser();

            return Task.FromResult(AuthenticateResult.NoResult());
        }
    }
}