using Binder.Application.Models.Interfaces;
using Binder.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    public class TestController
    {
        private readonly IDefaultTableService _service;

        public TestController(IDefaultTableService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getTask")]
        public ActionResult<ToDoTask> GetHelloText(int taskId)
        {
            return _service.GetTask(taskId);
        }
    }
}