using Binder.Core.Models;

namespace Binder.Persistence.Models.Interfaces
{
    public interface IDefaultTableRepository : IDisposable
    {
        DefaultTable? GetById(int tableId);

        ICollection<DefaultTable>? GetAll();

        DefaultTable Add(DefaultTable table);
    }
}