using Binder.Api.Models;
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
        public ActionResult<ToDoTask[]> Get(int tableId, TaskShow showFiltering)
        {
            return showFiltering switch
            {
                TaskShow.ShowCompleted => Ok(_service.GetTasksForTable(tableId).Where(x => x.IsCompleted == true)),
                TaskShow.HideCompleted => Ok(_service.GetTasksForTable(tableId).Where(x => x.IsCompleted == false)),
                TaskShow.ShowAll => Ok(_service.GetTasksForTable(tableId)),
                _ => NotFound(),
            };
        }

        [HttpPost]
        public ActionResult<ToDoTask> Post(ToDoTask task)
        {
            return _service.AddTaskToTable(task);
        }
    }
}