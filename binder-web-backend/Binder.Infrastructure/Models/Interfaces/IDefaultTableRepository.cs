using Binder.Core.Models;

namespace Binder.Infrastructure.Models.Interfaces
{
    public interface IDefaultTableRepository : IDisposable
    {
        DefaultTable? GetTableById(int tableId);

        ICollection<ToDoTask>? GetTasksByTable(int tableId);

        ToDoTask? GetTaskById(int taskId);
    }
}