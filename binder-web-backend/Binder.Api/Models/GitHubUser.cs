namespace Binder.Api.Models
{
    public sealed record GitHubUser
    {
        public int Id { get; set; }

        public string AuthToken { get; set; }

        public GitHubUser()
        {
            AuthToken = string.Empty;
        }
    }
}