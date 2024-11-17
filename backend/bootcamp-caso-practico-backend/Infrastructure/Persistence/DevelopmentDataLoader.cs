using bootcamp_caso_practico_backend.Domain.Entities;

namespace bootcamp_caso_practico_backend.Infrastructure.Persistence
{
    public class DevelopmentDataLoader
    {
        private readonly ListContext userListContext;
        public DevelopmentDataLoader(ListContext userListContext)
        {
            this.userListContext = userListContext;
        }
        public void LoadData()
        {
            if (!userListContext.Roles.Any())
            {
                LoadRoles();
            }
            userListContext.SaveChanges();
            if (!userListContext.Users.Any())
            {
                LoadUsers();
            }
            userListContext.SaveChanges();
        }

        private void LoadRoles()
        {
            var roles = new Role[]
            {
                new Role{ Name="Administrador"},
                new Role{ Name="Contributor"}
            };
            foreach (Role role in roles)
            {
                userListContext.Roles.Add(role);
            }
        }
        private void LoadUsers()
        {
            var users = new User[]
            {
                new User{ Name="Pablo", LastName="Ramírez", Email="example01@email.com", RoleId=1},
                new User{ Name="Roberto", LastName="González", Email="example02@email.com", RoleId=2},
                new User{ Name="Juan", LastName="Martínez", Email="example03@email.com", RoleId=1},
            };
            foreach (User user in users)
            {
                userListContext.Users.Add(user);
            }
        }
    }
}
