using AutoMapper;
using bootcamp_users_maintenance.Application.Dtos;
using bootcamp_users_maintenance.Domain.Entities;

namespace bootcamp_users_maintenance.Application.Mapping
{
    public class RoleMapperProfile : Profile
    {
        public RoleMapperProfile()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
        }
    }
}
