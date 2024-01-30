using AutoMapper;
using Binder.Api.Models;
using Binder.Application.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Binder.Api.Controllers
{
    [Route("api/tables")]
    [ApiController]
    public sealed class TablesController : ControllerBase
    {
        private readonly IDefaultTableService _service;
        private readonly IMapper _mapper;

        public TablesController(IDefaultTableService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Route("{tableId}")]
        [HttpGet]
        public ActionResult<DefaultTableDTO> Get(int tableId)
        {
            return _mapper.Map<DefaultTableDTO>(_service.GetTable(tableId));
        }

        [HttpGet]
        public ActionResult<DefaultTableDTO[]> Get()
        {
            return Ok(_mapper.Map<DefaultTableDTO[]>(_service.GetAllTables()));
        }

        [HttpPost]
        public ActionResult<DefaultTable> Post(string tableName)
        {
            return _service.CreateTable(tableName);
        }
    }
}