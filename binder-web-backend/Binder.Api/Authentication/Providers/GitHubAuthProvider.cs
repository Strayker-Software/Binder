using Binder.Api.Authentication.Interfaces;
using Octokit;

namespace Binder.Api.Authentication.Providers
{
    public sealed class GitHubAuthProvider : IGitHubAuthProvider
    {
        private readonly IConfiguration _configuration;
        private readonly GitHubClient _client;

        public GitHubAuthProvider(IConfiguration config)
        {
            _configuration = config;
            _client = new GitHubClient(new ProductHeaderValue("strayker-software-binder"));
        }

        public bool IsAuthenticated() => _client.Credentials.GetToken() is not null;

        public string GetLoginUrl()
        {
            if (IsAuthenticated())
                return string.Empty;

            var request = new OauthLoginRequest(_configuration["clientId"])
            {
                Scopes = { "user" }
            };
            var oauthLoginUrl = _client.Oauth.GetGitHubLoginUrl(request);

            return oauthLoginUrl.OriginalString;
        }

        public string GetAuthToken(string gitHubCode)
        {
            if (!IsAuthenticated())
            {
                var tokenRequest = new OauthTokenRequest(
                    _configuration["clientId"],
                    _configuration["clientSecret"],
                    gitHubCode);
                var oauthToken = _client.Oauth.CreateAccessToken(tokenRequest).Result;
                var tokenValue = oauthToken.AccessToken;
                _client.Credentials = new Credentials(tokenValue);

                return tokenValue;
            }
            else
                return _client.Credentials.GetToken();
        }
    }
}