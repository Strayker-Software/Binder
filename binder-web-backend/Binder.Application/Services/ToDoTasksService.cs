using Binder.Application.Models.Interfaces;
using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core.Constants;
using Binder.Core.Models;
using Binder.Persistence.Models.Interfaces;

namespace Binder.Application.Services
{
    public sealed class ToDoTasksService : IToDoTasksService
    {
        private readonly IToDoTasksRepository _repository;

        public ToDoTasksService(IToDoTasksRepository repository)
        {
            _repository = repository;
        }

        public ICollection<ToDoTask> GetTasksForTable(int tableId)
        {
            return _repository.GetTasksByTable(tableId) ??
                throw new NotFoundException(ExceptionConstants.ResourceNotFoundMessage);
        }

        public ToDoTask AddTaskToTable(ToDoTask task)
        {
            var newTask = new ToDoTask(task.Name, task.Description, task.IsCompleted, task.TableId);

            return _repository.InsertTaskIntoTable(newTask) ??
                throw new InvalidOperationException(ExceptionConstants.InvalidOperationMessage);
        }
    }
}