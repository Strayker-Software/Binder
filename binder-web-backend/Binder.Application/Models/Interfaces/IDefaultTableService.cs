using Binder.Core.Models;

namespace Binder.Application.Models.Interfaces
{
    public interface IDefaultTableService
    {
        DefaultTable GetTable(int tableId);

        ICollection<DefaultTable> GetAllTables();

        DefaultTable CreateTable(string tableName);
    }
}