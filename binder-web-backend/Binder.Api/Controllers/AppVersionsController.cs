using Binder.Application.Models.Interfaces;
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
        public ActionResult<string> Get()
        {
            return _service.GetAppVersion();
        }
    }
}