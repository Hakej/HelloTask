using AutoMapper;
using HelloTask.Core.Models;
using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Assignment, AssignmentDto>();
                cfg.CreateMap<Tab, TabDto>();
            })
            .CreateMapper();
    }
}
