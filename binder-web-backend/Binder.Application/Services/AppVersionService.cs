using Binder.Application.Models.Interfaces;
using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core;
using Binder.Core.Models;
using Binder.Persistence.Models.Interfaces;

namespace Binder.Application.Services
{
    public class AppVersionService : IAppVersionService
    {
        private readonly IAppVersionRepository _repository;

        public AppVersionService(IAppVersionRepository repository)
        {
            _repository = repository;
        }

        public AppVersion GetAppVersion(int versionId)
        {
            return _repository.GetAppVersionById(versionId) ??
                   throw new NotFoundException(ExceptionConstants.NotFoundTitle);
        }

        public ICollection<AppVersion> GetAppVersions()
        {
            return _repository.GetAppVersions() ?? 
                   throw new NotFoundException(ExceptionConstants.NotFoundTitle);
        }
    }
}