using bootcamp_framework.Infraestructure.Rest;
using bootcamp_users_maintenance.Application.Dtos;
using bootcamp_users_maintenance.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace bootcamp_users_maintenance.Infraestructure.Rest
{
    [Route("userList/[controller]")]
    [ApiController]
    public class RolesController : GenericCrudController<RoleDto>
    {
        public RolesController(IRoleService roleService) : base(roleService)
        {
        }

    }
}
