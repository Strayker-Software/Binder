using Binder.Api.Authentication;
using Binder.Api.Authentication.Interfaces;
using Binder.Api.Authentication.Providers;
using Microsoft.AspNetCore.Authentication;

namespace Binder.Api.Extensions
{
    public static class AddGitHubAuthExtenstion
    {
        public static IServiceCollection AddGitHubAuth(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IGitHubAuthProvider, GitHubAuthProvider>();
            serviceCollection.AddAuthentication("GitHubAuth")
                .AddScheme<AuthenticationSchemeOptions, GitHubAuthHandler>("GitHubAuth", null);

            return serviceCollection;
        }
    }
}