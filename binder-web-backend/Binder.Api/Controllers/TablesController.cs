using Binder.Application.Models.Interfaces;
using Binder.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    [Route("api/tables")]
    [ApiController]
    public sealed class TablesController : ControllerBase
    {
        private readonly IDefaultTableService _service;

        public TablesController(IDefaultTableService service)
        {
            _service = service;
        }

        [Route("{tableId}")]
        [HttpGet]
        public ActionResult<DefaultTable> Get(int tableId)
        {
            return _service.GetTable(tableId);
        }

        [HttpGet]
        public ActionResult<DefaultTable[]> Get()
        {
            return Ok(_service.GetAllTables());
        }

        [HttpPost]
        public ActionResult<DefaultTable> Create(string tableName)
        {
            return _service.Create(tableName);
        }
    }
}