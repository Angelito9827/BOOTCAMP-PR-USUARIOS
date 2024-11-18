using bootcamp_caso_practico_backend.Domain.Entities;
using bootcamp_caso_practico_backend.Domain.Persistence;
using bootcamp_caso_practico_backend.Infrastructure.Persistence;
using bootcamp_framework.Infraestructure.Persistence;

namespace bootcamp_caso_practico_backend.Infraestructure.Persistence
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private ListContext _userListContext;

        public RoleRepository(ListContext context) : base(context)
        {
            _userListContext = context;
        }
    }
}
