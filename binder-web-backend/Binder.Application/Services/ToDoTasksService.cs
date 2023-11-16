using Binder.Application.Models.Interfaces;
using Binder.Core.Constants;
using Binder.Core.Models;
using Binder.Persistence.Models.Interfaces;

namespace Binder.Application.Services
{
    public class ToDoTasksService : IToDoTasksService
    {
        private readonly IToDoTasksRepository _repository;

        public ToDoTasksService(IToDoTasksRepository repository)
        {
            _repository = repository;
        }

        public ICollection<ToDoTask> GetTasksForTable(int tableId)
        {
            return _repository.GetTasksByTable(tableId) ??
                   throw new ArgumentException(ExceptionConstants.ResourceNotFoundMessage);
        }
    }
}