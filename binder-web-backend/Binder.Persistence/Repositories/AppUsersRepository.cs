using Binder.Core.Models;
using Binder.Persistence.Contexts;
using Binder.Persistence.Models.Interfaces;

namespace Binder.Persistence.Repositories
{
    public class AppUsersRepository : IAppUsersRepository
    {
        private bool disposed = false;
        private readonly BinderDbContext _context;

        public AppUsersRepository(BinderDbContext context)
        {
            _context = context;
        }

        public AppUser? GetByToken(string token)
        {
            return _context.Users
                .FirstOrDefault(user => user.Token.Equals(token));
        }

        public ICollection<AppUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}