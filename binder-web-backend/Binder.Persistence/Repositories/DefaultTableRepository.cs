using Binder.Core.Models;
using Binder.Persistence.Contexts;
using Binder.Persistence.Models.Interfaces;

namespace Binder.Persistence.Repositories
{
    public class DefaultTableRepository : IDefaultTableRepository
    {
        private bool disposed = false;
        private readonly BinderDbContext _context;

        public DefaultTableRepository(BinderDbContext context)
        {
            _context = context;
        }

        public DefaultTable? GetById(int tableId)
        {
            return _context.Tables
                .FirstOrDefault(searchTable => searchTable.Id == tableId);
        }

        public ICollection<DefaultTable>? GetAll()
        {
            return _context.Tables.ToList().Count != 0 ? _context.Tables.ToList() : null;
        }

        public DefaultTable Add(DefaultTable table)
        {
            _context.Tables.Add(table);
            _context.SaveChanges();

            return table;
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