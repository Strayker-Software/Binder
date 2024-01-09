using Binder.Application.Models.Interfaces;
using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core.Constants;
using Binder.Core.Models;
using Binder.Persistence.Models.Interfaces;

namespace Binder.Application.Services
{
    public sealed class DefaultTableService : IDefaultTableService
    {
        private readonly IDefaultTableRepository _defaultTableRepository;
        private readonly IToDoTasksRepository _toDoTasksRepository;

        public DefaultTableService(
            IDefaultTableRepository defaultTableRepository,
            IToDoTasksRepository toDoTasksRepository)
        {
            _defaultTableRepository = defaultTableRepository;
            _toDoTasksRepository = toDoTasksRepository;
        }

        public DefaultTable GetTable(int tableId)
        {
            var table = _defaultTableRepository.GetById(tableId) ??
                throw new NotFoundException(ExceptionConstants.ResourceNotFoundMessage);
            table.Tasks = _toDoTasksRepository.GetTasksByTable(tableId) ??
                throw new NotFoundException(ExceptionConstants.ResourceNotFoundMessage);

            return table;
        }

        public ICollection<DefaultTable> GetAllTables()
        {
            var tables = _defaultTableRepository.GetAll() ??
                throw new NotFoundException(ExceptionConstants.ResourceNotFoundMessage);

            foreach (var table in tables)
            {
                table.Tasks = _toDoTasksRepository.GetTasksByTable(table.Id) ??
                    throw new NotFoundException(ExceptionConstants.ResourceNotFoundMessage);
            }

            return tables;
        }
    }
}