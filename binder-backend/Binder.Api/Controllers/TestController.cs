using Binder.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    public class TestController
    {
        [HttpGet]
        [Route("hello")]
        public string GetHelloText()
        {
            return new TestService().GetHelloMessage();
        }
    }
}