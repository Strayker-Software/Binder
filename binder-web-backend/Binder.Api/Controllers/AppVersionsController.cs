using Binder.Application.Models.Interfaces;
using Binder.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    public class AppVersionsController
    {
        private readonly IAppVersionService _service;

        public AppVersionsController(IAppVersionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetVersion")]
        public ActionResult<AppVersion> Get(int versionId)
        {
            return _service.GetAppVersion(versionId);
        }

        [HttpGet]
        [Route("GetAllVersions")]
        public ActionResult<IList<AppVersion>> GetAll()
        {
            return _service.GetAppVersions().ToList();
        }
    }
}