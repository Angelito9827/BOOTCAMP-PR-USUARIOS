using AutoMapper;
using bootcamp_framework.Application.Services;
using bootcamp_users_maintenance.Application.Dtos;
using bootcamp_users_maintenance.Domain.Entities;
using bootcamp_users_maintenance.Domain.Persistence;

namespace bootcamp_users_maintenance.Application.Services
{
    public class RoleService : GenericService<Role, RoleDto>, IRoleService
    {
        public RoleService(IRoleRepository roleRepository, IMapper mapper) : base(roleRepository, mapper)
        {
        }
    }
}
