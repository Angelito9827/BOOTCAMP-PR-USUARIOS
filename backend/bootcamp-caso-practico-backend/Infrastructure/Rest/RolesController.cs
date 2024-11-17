using bootcamp_caso_practico_backend.Application.Dtos;
using bootcamp_caso_practico_backend.Application.Services;
using bootcamp_framework.Infraestructure.Rest;
using Microsoft.AspNetCore.Mvc;

namespace bootcamp_users_maintenance.Infraestructure.Rest
{
    [Route("/[controller]")]
    [ApiController]
    public class RolesController : GenericCrudController<RoleDto>
    {
        public RolesController(IRoleService roleService) : base(roleService)
        {
        }

    }
}
