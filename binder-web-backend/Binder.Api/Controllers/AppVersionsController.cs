using Binder.Application.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    [Route("api/versions")]
    [ApiController]
    public sealed class AppVersionsController : ControllerBase
    {
        private readonly IAppVersionService _service;

        public AppVersionsController(IAppVersionService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return _service.GetAppVersion();
        }
    }
}