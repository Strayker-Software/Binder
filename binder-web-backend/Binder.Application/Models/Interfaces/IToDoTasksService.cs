using Binder.Core.Models;

namespace Binder.Application.Models.Interfaces
{
    public interface IToDoTasksService
    {
        ICollection<ToDoTask> GetTasksForTable(int tableId);
    }
}