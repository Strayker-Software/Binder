using Binder.Core.Models;

namespace Binder.Application.Models.Interfaces
{
    public interface IDefaultTableService
    {
        ToDoTask GetTask(int taskId);
    }
}