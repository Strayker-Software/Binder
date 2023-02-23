using Binder.Core.Models;

namespace Binder.Infrastructure.Models.Interfaces
{
    public interface ITestRepository : IDisposable
    {
        ICollection<BaseEntity> GetBaseEntities();
    }
}