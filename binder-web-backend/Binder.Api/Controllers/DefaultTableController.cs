using Binder.Application.Models.Interfaces;
using Binder.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    [Route("table")]
    public class DefaultTableController
    {
        private readonly IDefaultTableService _service;

        public DefaultTableController(IDefaultTableService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<DefaultTable> Get(int tableId)
        {
            return _service.GetTableWithTasks(tableId);
        }
    }
}