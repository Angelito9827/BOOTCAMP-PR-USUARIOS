using bootcamp_framework.Application.Dtos;

namespace bootcamp_caso_practico_backend.Application.Dtos
{
    public class UserDto : IDto
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public long RoleId { get; set; }

        public required string RoleName { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
