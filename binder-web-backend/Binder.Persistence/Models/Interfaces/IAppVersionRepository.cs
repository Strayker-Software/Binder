using Binder.Core.Models;

namespace Binder.Persistence.Models.Interfaces
{
    public interface IAppVersionRepository : IDisposable
    {
        AppVersion? GetAppVersionById(int versionId);
        ICollection<AppVersion>? GetAppVersions();
    }
}