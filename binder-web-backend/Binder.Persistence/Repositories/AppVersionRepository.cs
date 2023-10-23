using Binder.Core.Models;
using Binder.Persistence.Contexts;
using Binder.Persistence.Models.Interfaces;

namespace Binder.Persistence.Repositories
{
    public class AppVersionRepository : IAppVersionRepository
    {
        private bool disposed = false;
        private readonly BinderDbContext _context;

        public AppVersionRepository(BinderDbContext context)
        {
            _context = context;
        }

        public AppVersion? GetAppVersionById(int versionId)
        {
            return _context.AppVersions.FirstOrDefault(searchVersion => searchVersion.Id == versionId);
        }

        public ICollection<AppVersion>? GetAppVersions()
        {
            return _context.AppVersions.ToList();
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