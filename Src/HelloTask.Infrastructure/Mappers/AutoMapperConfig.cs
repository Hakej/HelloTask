using AutoMapper;
using HelloTask.Core.Domain;
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
                cfg.CreateMap<Tab, TabDetailsDto>();
                cfg.CreateMap<Board, BoardDto>();
                cfg.CreateMap<Board, BoardDetailsDto>();
                cfg.CreateMap<User, UserDto>();
            })
            .CreateMapper();
    }
}
