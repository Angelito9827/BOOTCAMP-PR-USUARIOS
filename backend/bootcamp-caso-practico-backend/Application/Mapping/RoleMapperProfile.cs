using AutoMapper;
using bootcamp_caso_practico_backend.Application.Dtos;
using bootcamp_caso_practico_backend.Domain.Entities;

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
