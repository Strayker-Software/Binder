using Binder.Core.Models;
using Binder.Infrastructure.Contexts;
using Binder.Infrastructure.Models.Interfaces;

namespace Binder.Infrastructure.Repositories
{
    public class BaseEntitiesRepository : ITestRepository
    {
        private bool disposed = false;
        private readonly TestDbContext _context;

        public BaseEntitiesRepository(TestDbContext context)
        {
            _context = context;
        }

        public ICollection<BaseEntity> GetBaseEntities()
        {
            return _context.BaseEntities.ToArray();
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