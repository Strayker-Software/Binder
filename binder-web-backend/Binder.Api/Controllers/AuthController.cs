using Binder.Api.Authentication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    [ApiController]
    public sealed class AuthController : ControllerBase
    {
        private readonly IGitHubAuthProvider _provider;
        private readonly IConfiguration _config;

        public AuthController(IGitHubAuthProvider provider, IConfiguration config)
        {
            _provider = provider;
            _config = config;
        }

        [Route("login")]
        [HttpGet]
        public ActionResult<string> Login()
        {
            return Ok(_provider.GetLoginUrl());
        }

        [Route("callback")]
        [HttpPost]
        public ActionResult<string> Callback([FromQuery] string code)
        {
            return Ok(_provider.GetAuthToken(code));
        }
    }
}