using Binder.Application.Models.Interfaces;
using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core.Constants;
using Binder.Core.Models;
using Binder.Persistence.Models.Interfaces;

namespace Binder.Application.Services
{
    public sealed class ToDoTasksService : IToDoTasksService
    {
        private readonly IToDoTasksRepository _toDoTaskRepository;
        private readonly IDefaultTableRepository _defaultTableRepository;

        public ToDoTasksService(IToDoTasksRepository toDoTaskRepository, IDefaultTableRepository defaultTableRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _defaultTableRepository = defaultTableRepository;
        }

        public ICollection<ToDoTask> GetTasksForTable(int tableId)
        {
            return _toDoTaskRepository.GetTasksByTable(tableId) ??
                throw new NotFoundException(ExceptionConstants.ResourceNotFoundMessage);
        }

        public ToDoTask AddTaskToTable(ToDoTask task)
        {
            task.Table = _defaultTableRepository.GetById(task.TableId) ??
                throw new NotFoundException(ExceptionConstants.ResourceNotFoundMessage);

            return _toDoTaskRepository.InsertTaskIntoTable(task) ??
                throw new InvalidOperationException(ExceptionConstants.InvalidOperationMessage);
        }
    }
}