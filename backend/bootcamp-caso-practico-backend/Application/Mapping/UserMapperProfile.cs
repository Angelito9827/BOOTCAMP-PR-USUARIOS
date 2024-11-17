using AutoMapper;
using bootcamp_caso_practico_backend.Application.Dtos;
using bootcamp_caso_practico_backend.Domain.Entities;

namespace bootcamp_caso_practico_backend.Application.Mapping
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserDto>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
            CreateMap<UserDto, User>();
        }
    }
}
