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
    }
}
