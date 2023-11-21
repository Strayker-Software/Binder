using Binder.Application.Models.Interfaces;
using Binder.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    [Route("tables")]
    [ApiController]
    public sealed class TablesController : ControllerBase
    {
        private readonly IDefaultTableService _service;

        public TablesController(IDefaultTableService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{tableId}")]
        public ActionResult<DefaultTable> Get(int tableId)
        {
            return _service.GetTable(tableId);
        }

        [HttpGet]
        public ActionResult<DefaultTable[]> Get()
        {
            return Ok(_service.GetAllTables());
        }
    }
}