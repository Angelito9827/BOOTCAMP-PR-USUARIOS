using bootcamp_framework.Infraestructure.Persistence;
using bootcamp_users_maintenance.Domain.Entities;
using bootcamp_users_maintenance.Domain.Persistence;

namespace bootcamp_users_maintenance.Infraestructure.Persistence
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private UserListContext _userListContext;

        public RoleRepository(UserListContext context) : base(context)
        {
            _userListContext = context;
        }
    }
}
