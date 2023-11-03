using Binder.Core.Models;

namespace Binder.Persistence.Models.Interfaces
{
    public interface IToDoTasksRepository : IDisposable
    {
        ICollection<ToDoTask>? GetTasksByTable(int tableId);
    }
}