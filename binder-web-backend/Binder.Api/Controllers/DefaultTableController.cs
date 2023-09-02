using Binder.Application.Models.Interfaces;
using Binder.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    public class DefaultTableController
    {
        private readonly IDefaultTableService _service;

        public DefaultTableController(IDefaultTableService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetToDoTask")]
        public ActionResult<ToDoTask> Get(int taskId)
        {
            return _service.GetTask(taskId);
        }
    }
}