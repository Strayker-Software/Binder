using Binder.Core.Models;
using Binder.Infrastructure.Contexts;
using Binder.Infrastructure.Models.Interfaces;

namespace Binder.Infrastructure.Repositories
{
    public class DefaultTableRepository : IDefaultTableRepository
    {
        private bool disposed = false;
        private readonly BinderDbContext _context;

        public DefaultTableRepository(BinderDbContext context)
        {
            _context = context;
        }

        public DefaultTable GetTableById(int tableId)
        {
            return _context.Tables.FirstOrDefault(searchTable => searchTable.Id == tableId);
        }

        public ICollection<ToDoTask> GetTasksByTable(int tableId)
        {
            var requestedTable = _context.Tables.FirstOrDefault(searchTable => searchTable.Id == tableId);

            if (requestedTable != null)
            {
                return (ICollection<ToDoTask>)requestedTable.Tasks;
            }
            else return new List<ToDoTask>();
        }

        public ToDoTask GetTaskById(int taskId)
        {
            return _context.ToDoTasks.FirstOrDefault(searchTask => searchTask.Id == taskId);
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