using AutoMapper;
using bootcamp_users_maintenance.Application.Dtos;
using bootcamp_users_maintenance.Domain.Entities;

namespace bootcamp_users_maintenance.Application.Mapping
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
