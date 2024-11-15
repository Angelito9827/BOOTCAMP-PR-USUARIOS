using bootcamp_framework.Application.Dtos;

namespace bootcamp_users_maintenance.Application.Dtos
{
    public class UserDto : IDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long RoleId { get; set; }

        public string RoleName { get; set; }
    }
}
