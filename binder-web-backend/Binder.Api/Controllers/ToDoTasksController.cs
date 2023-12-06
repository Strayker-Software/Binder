using Binder.Application.Models.Interfaces;
using Binder.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public sealed class ToDoTasksController : ControllerBase
    {
        private readonly IToDoTasksService _service;

        public ToDoTasksController(IToDoTasksService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ToDoTask[]> Get(int tableId)
        {
            return Ok(_service.GetTasksForTable(tableId));
        }
    }
}