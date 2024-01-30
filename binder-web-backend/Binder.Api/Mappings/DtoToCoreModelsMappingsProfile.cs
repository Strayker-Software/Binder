using AutoMapper;
using Binder.Api.Models;
using Binder.Core.Models;

namespace Binder.Api.Mappings
{
    public class DtoToCoreModelsMappingsProfile : Profile
    {
        public DtoToCoreModelsMappingsProfile()
        {
            CreateMap<ToDoTask, ToDoTaskDTO>()
                .ReverseMap();
            CreateMap<DefaultTable, DefaultTableDTO>();
        }
    }
}