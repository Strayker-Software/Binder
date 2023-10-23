using Binder.Core.Models;

namespace Binder.Application.Models.Interfaces
{
    public interface IAppVersionService
    {
        AppVersion GetAppVersion(int id);
        ICollection<AppVersion> GetAppVersions();
    }
}