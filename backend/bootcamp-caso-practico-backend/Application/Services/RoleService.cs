using AutoMapper;
using bootcamp_caso_practico_backend.Application.Dtos;
using bootcamp_caso_practico_backend.Domain.Entities;
using bootcamp_caso_practico_backend.Domain.Persistence;
using bootcamp_framework.Application.Services;

namespace bootcamp_caso_practico_backend.Application.Services
{
    public class RoleService : GenericService<Role, RoleDto>, IRoleService
    {
        public RoleService(IRoleRepository roleRepository, IMapper mapper) : base(roleRepository, mapper)
        {
        }
    }
}
