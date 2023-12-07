using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public sealed class AuthController : ControllerBase
    {
        [Route("callback")]
        [HttpPost]
        public void Callback([FromQuery] string code)
        {
        }
    }
}