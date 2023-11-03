using Binder.Core.Models;
using Binder.Persistence.Contexts;
using Binder.Persistence.Models.Interfaces;

namespace Binder.Persistence.Repositories
{
    public class ToDoTasksRepository : IToDoTasksRepository
    {
        private bool disposed = false;
        private readonly BinderDbContext _context;

        public ToDoTasksRepository(BinderDbContext context)
        {
            _context = context;
        }

        public ICollection<ToDoTask>? GetTasksByTable(int tableId)
        {
            var requestedTable = _context.Tables
                .FirstOrDefault(searchTable => searchTable.Id == tableId);

            var tasks = _context.ToDoTasks.Where(task => task.TableId == tableId);

            return tasks.ToList();
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