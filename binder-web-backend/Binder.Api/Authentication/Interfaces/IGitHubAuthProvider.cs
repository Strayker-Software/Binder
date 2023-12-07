using Binder.Api.Models;

namespace Binder.Api.Authentication.Interfaces
{
    public interface IGitHubAuthProvider
    {
        GitHubUser GetCurrentUser();
    }
}