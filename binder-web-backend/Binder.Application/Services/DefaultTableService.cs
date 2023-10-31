using Binder.Application.Models.Interfaces;
using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core.Constants;
using Binder.Core.Models;
using Binder.Persistence.Models.Interfaces;

namespace Binder.Application.Services
{
    public class DefaultTableService : IDefaultTableService
    {
        private readonly IDefaultTableRepository _repository;

        public DefaultTableService(IDefaultTableRepository repository)
        {
            _repository = repository;
        }

        public DefaultTable GetTableWithTasks(int tableId)
        {
            return _repository.GetTableById(tableId) ??
                throw new NotFoundException(ExceptionConstants.ResourceNotFoundMessage);
        }
    }
}