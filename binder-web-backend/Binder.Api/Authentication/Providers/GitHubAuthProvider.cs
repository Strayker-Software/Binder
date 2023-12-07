using Binder.Api.Authentication.Interfaces;
using Binder.Api.Models;
using Octokit;

namespace Binder.Api.Authentication.Providers
{
    public sealed class GitHubAuthProvider : IGitHubAuthProvider
    {
        private IConfiguration _configuration;

        public GitHubAuthProvider(IConfiguration config)
        {
            _configuration = config;
        }

        public GitHubUser GetCurrentUser()
        {
            var currentUser = new GitHubUser();

            var client = new GitHubClient(new ProductHeaderValue("strayker-software-binder"));

            var request = new OauthLoginRequest(_configuration["clientId"])
            {
                Scopes = { "user" }
            };

            var oauthLoginUrl = client.Oauth.GetGitHubLoginUrl(request);

            // Send login url to user here.

            var tokenRequest = new OauthTokenRequest(
                _configuration["clientId"],
                _configuration["clientSecret"],
                "returnedCode");
            var token = client.Oauth.CreateAccessToken(tokenRequest).Result;
            var ok = token.AccessToken;
            client.Credentials = new Credentials(ok);

            currentUser.Id = client.User.Current().Result.Id;

            return currentUser;
        }
    }
}