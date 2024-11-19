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
                new User{ Name="Juan", LastName="Martínez", Email="example03@email.com", RoleId=1},
                new User{ Name="Ana", LastName="González", Email="ana.gonzalez@email.com", RoleId=2},
                new User{ Name="Carlos", LastName="Pérez", Email="carlos.perez@email.com", RoleId=1},
                new User{ Name="Lucía", LastName="Rodríguez", Email="lucia.rodriguez@email.com", RoleId=1},
                new User{ Name="Pedro", LastName="López", Email="pedro.lopez@email.com", RoleId=2},
                new User{ Name="María", LastName="Sánchez", Email="maria.sanchez@email.com", RoleId=2},
                new User{ Name="José", LastName="Fernández", Email="jose.fernandez@email.com", RoleId=1},
                new User{ Name="Isabel", LastName="Torres", Email="isabel.torres@email.com", RoleId=2},
                new User{ Name="David", LastName="Ramírez", Email="david.ramirez@email.com", RoleId=1},
                new User{ Name="Laura", LastName="Díaz", Email="laura.diaz@email.com", RoleId=1},
                new User{ Name="Javier", LastName="Álvarez", Email="javier.alvarez@email.com", RoleId=2},
                new User{ Name="Elena", LastName="Mora", Email="elena.mora@email.com", RoleId=2},
                new User{ Name="Fernando", LastName="García", Email="fernando.garcia@email.com", RoleId=1}

            };
            foreach (User user in users)
            {
                userListContext.Users.Add(user);
            }
        }
    }
}
