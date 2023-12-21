using Binder.Core.Models;

namespace Binder.Persistence.Models.Interfaces
{
    public interface IAppUsersRepository : IDisposable
    {
        ICollection<AppUser> GetUsers();

        AppUser? GetByToken(string token);
    }
}