using Binder.Application.Models.Interfaces;
using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core.Constants;
using Binder.Core.Models;
using Binder.Persistence.Models.Interfaces;

namespace Binder.Application.Services
{
    public sealed class DefaultTableService : IDefaultTableService
    {
        private readonly IDefaultTableRepository _repository;

        public DefaultTableService(IDefaultTableRepository repository)
        {
            _repository = repository;
        }

        public DefaultTable GetTable(int tableId)
        {
            return _repository.GetById(tableId) ??
                throw new NotFoundException(ExceptionConstants.ResourceNotFoundMessage);
        }

        public ICollection<DefaultTable> GetAllTables()
        {
            return _repository.GetAll() ??
                throw new NotFoundException(ExceptionConstants.ResourceNotFoundMessage);
        }

        public DefaultTable CreateTable(string tableName)
        {            
            var table = new DefaultTable
            {
                Name = tableName
            };
            
            return _repository.Add(table) ??
                throw new InvalidOperationException(ExceptionConstants.InvalidOperationMessage);
        }
    }
}