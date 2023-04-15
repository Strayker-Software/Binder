using Binder.Application.Models.Interfaces;
using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core;
using Binder.Core.Models;
using Binder.Infrastructure.Models.Interfaces;

namespace Binder.Application.Services
{
    public class DefaultTableService : IDefaultTableService
    {
        private readonly IDefaultTableRepository _repository;

        public DefaultTableService(IDefaultTableRepository repository)
        {
            _repository = repository;
        }

        public ToDoTask GetTask(int taskId)
        {
            return _repository.GetTaskById(taskId) ?? throw new NotFoundException(ExceptionConstants.NotFoundTitle);
        }
    }
}