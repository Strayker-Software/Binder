using AutoMapper;
using Binder.Api.Models;
using Binder.Application.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public sealed class ToDoTasksController : ControllerBase
    {
        private readonly IToDoTasksService _service;
        private readonly IMapper _mapper;

        public ToDoTasksController(IToDoTasksService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ToDoTaskDTO[]> Get(int tableId)
        {
            return Ok(_mapper.Map<ToDoTaskDTO[]>(_service.GetTasksForTable(tableId)));
        }
    }
}