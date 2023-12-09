namespace Binder.Api.Authentication.Interfaces
{
    public interface IGitHubAuthProvider
    {
        string GetLoginUrl();

        string GetAuthToken(string gitHubCode);

        bool IsAuthenticated();
    }
}