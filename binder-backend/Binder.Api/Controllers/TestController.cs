using Binder.Application.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    public class TestController
    {
        private readonly ITestService _service;

        public TestController(ITestService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("hello")]
        public ActionResult<string> GetHelloText()
        {
            return _service.GetFirstEntityName();
        }
    }
}